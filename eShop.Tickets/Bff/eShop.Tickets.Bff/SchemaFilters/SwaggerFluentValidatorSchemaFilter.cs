using FluentValidation;
using FluentValidation.Validators;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

#nullable disable

namespace eShop.Tickets.Bff.SchemaFilters
{
    public class SwaggerFluentValidatorSchemaFilter : ISchemaFilter
    {
        public SwaggerFluentValidatorSchemaFilter() 
        { 
            Validators = Assembly.GetEntryAssembly()?.GetTypes().Where(type => type.IsAbstract && type.IsGenericType && type.GetGenericTypeDefinition() == typeof(AbstractValidator<>));
        }

        protected IEnumerable<Type> Validators { get; private set; }

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {

            var validator = Validators?.FirstOrDefault(v => v.BaseType?.GetGenericArguments().First() == context.Type);
            if (validator != null)
            {
                var properties = schema.Properties;
                if (properties != null)
                {
                    foreach (var property in properties)
                    {
                        var validatorInstance = (IValidator)Activator.CreateInstance(validator);
                        var propertyValidators = validatorInstance.CreateDescriptor().GetValidatorsForMember(property.Key);
                        foreach (var propertyValidator in propertyValidators)
                        {
                            if (propertyValidator.GetType().GetGenericTypeDefinition() == typeof(NotNullValidator<,>))
                            {
                                property.Value.Nullable = false;
                            }
                            //if (propertyValidator.GetType().GetGenericTypeDefinition() == typeof(LengthValidator<>))
                            //{
                            //    var lengthValidator = (LengthValidator)propertyValidator;
                            //    property.Value.MinLength = lengthValidator.Min;
                            //    property.Value.MaxLength = lengthValidator.Max;
                            //}
                            //if (propertyValidator is RegularExpressionValidator regexValidator)
                            //{
                            //    property.Value.Pattern = regexValidator.Expression;
                            //}
                        }
                    }
                }
            }
        }
    }
}
