using FluentValidation;
using System.Linq;

namespace Northwind.UseCases.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderInputPort>
    {
        public CreateOrderValidator()
        {
            RuleFor(c => c.RequestData.CustomerId).NotEmpty().WithMessage("Debe proporcionar el identificador del cliente");
            RuleFor(c => c.RequestData.ShipAddress).NotEmpty().WithMessage("Debe proporcionar la dirección de envío");
            RuleFor(c => c.RequestData.ShipCity).NotEmpty().MinimumLength(3)
                .WithMessage("Debe proporcionar al menos 3 caracteres del nombre de la ciudad");
            RuleFor(c => c.RequestData.ShipCountry).NotEmpty().MinimumLength(3)
                .WithMessage("Debe proporcionar al menos 3 caracteres del nombre del país");
            RuleFor(c => c.RequestData.OrderDetails).Must(d => d != null && d.Any())
                .WithMessage("Debe especificarse los productos de la orden");
        }
    }
}