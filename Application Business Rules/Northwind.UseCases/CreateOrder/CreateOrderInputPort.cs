using MediatR;
using Northwind.UseCasesDTOs.CreateOrder;

namespace Northwind.UseCases.CreateOrder
{
    public class CreateOrderInputPort : CreateOrderParams, IRequest<int>
    {
        
    }
}