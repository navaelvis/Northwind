using MediatR;
using Northwind.Entities.Exceptions;
using Northwind.Entities.Interfaces;
using Northwind.Entities.POCOEntities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.UseCases.CreateOrder
{
    public class CreateOrderInteractor //: IRequestHandler<CreateOrderInputPort, int>
    {
        readonly IOrderRepository _orderRepository;
        readonly IOrderDetailRepository _orderDetailRepository;
        readonly IUnitOfWork _unitOfWork;
        public CreateOrderInteractor(IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IUnitOfWork unitOfWork) =>
            (_orderRepository, _orderDetailRepository, _unitOfWork) =
            (orderRepository, orderDetailRepository, unitOfWork);
        public async System.Threading.Tasks.Task<int> Handle(CreateOrderInputPort request,
            CancellationToken cancellationToken)
        {
            Order order = new Order
            {
                CustomerId = request.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = request.ShipAddress,
                ShipCity = request.ShipCity,
                ShipCountry = request.ShipPostalCode,
                ShipPostalCode = request.ShipPostalCode,
                ShippingType = Entities.Enums.ShippingType.Road,
                DiscountType = Entities.Enums.DiscountType.Percentage,
                Discount = 10
            };
            _orderRepository.Create(order);

            foreach (var detail in request.OrderDetails)
            {
                _orderDetailRepository.Create(
                    new OrderDetail
                    {
                        Order = order,
                        ProductId = detail.ProductId,
                        UnitPrice = detail.UnitPrice,
                        Quantity = detail.Quantity
                    }
                );
            }

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear la orden", ex.Message);
            }

            return order.Id;
        }
    }
}