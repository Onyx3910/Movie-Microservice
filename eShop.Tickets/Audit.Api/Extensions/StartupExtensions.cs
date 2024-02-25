using Audit.Api.Controllers;
using Audit.Domain.AggregatesModel.AuditLogAggregate;
using Audit.Infrastructure;
using Audit.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Audit.Api.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddAuditServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuditContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Audit"));
            });

            services.AddScoped<ILogRepository>(provider =>
            {
                var context = provider.GetRequiredService<AuditContext>();
                return new AuditLogRepository(context);
            });

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(AuditController).Assembly);
            });

            return services;
        }
    }
}
