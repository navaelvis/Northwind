using MediatR;
using Northwind.UseCases.Common.Ports;
using Northwind.UseCasesDTOs.CreateOrder;

namespace Northwind.UseCases.CreateOrder
{
    public class CreateOrderInputPort : IInputPort<CreateOrderParams, int>
    {
        public CreateOrderParams RequestData { get; }
        public IOutputPort<int> OutputPort { get; }
        public CreateOrderInputPort(CreateOrderParams requestData, IOutputPort<int> outputPort) =>
            (RequestData, OutputPort) = (requestData, outputPort);
    }
}