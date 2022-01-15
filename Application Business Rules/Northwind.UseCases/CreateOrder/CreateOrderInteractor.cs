using MediatR;
using Northwind.Entities.Exceptions;
using Northwind.Entities.Interfaces;
using Northwind.Entities.POCOEntities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.UseCases.CreateOrder
{
    public class CreateOrderInteractor : AsyncRequestHandler<CreateOrderInputPort>
    {
        readonly IOrderRepository _orderRepository;
        readonly IOrderDetailRepository _orderDetailRepository;
        readonly IUnitOfWork _unitOfWork;
        public CreateOrderInteractor(IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IUnitOfWork unitOfWork) =>
            (_orderRepository, _orderDetailRepository, _unitOfWork) =
            (orderRepository, orderDetailRepository, unitOfWork);
        protected async override Task Handle(CreateOrderInputPort request,
            CancellationToken cancellationToken)
        {
            Order order = new Order
            {
                CustomerId = request.RequestData.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = request.RequestData.ShipAddress,
                ShipCity = request.RequestData.ShipCity,
                ShipCountry = request.RequestData.ShipPostalCode,
                ShipPostalCode = request.RequestData.ShipPostalCode,
                ShippingType = Entities.Enums.ShippingType.Road,
                DiscountType = Entities.Enums.DiscountType.Percentage,
                Discount = 10
            };
            _orderRepository.Create(order);

            foreach (var detail in request.RequestData.OrderDetails)
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

            request.OutputPort.Handle(order.Id);
        }
    }
}