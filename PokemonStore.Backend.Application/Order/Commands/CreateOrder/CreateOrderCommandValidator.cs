using FluentValidation;

namespace PokemonStore.Backend.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(v => v.Order.Items)
                .Must(orders => orders.Count > 0).WithMessage("The Order must have one or more Items");

            RuleForEach(v => v.Order.Items)
                .ChildRules(orders => 
                {
                    orders.RuleFor(item => item.ProductId).NotEmpty().WithMessage($"The ProductId for each item is required");
                    orders.RuleFor(item => item.Ammount).GreaterThan(0).WithMessage($"The Ammount for each item must be grater than 0");
                });
        }
    }
}
