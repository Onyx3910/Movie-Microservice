using eShop.Tickets.Bff.Domain.Requests;
using FluentValidation;

namespace eShop.Tickets.Bff.Validators
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(x => x.TheaterId).NotEmpty();
            RuleFor(x => x.MovieId).NotEmpty();
            RuleFor(x => x.ShowTime)
                .NotEmpty()
                .GreaterThan(DateTime.Now);
        }
    }
}
