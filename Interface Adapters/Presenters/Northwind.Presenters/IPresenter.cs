using Northwind.UseCases.Common.Ports;

namespace Northwind.Presenters
{
    public interface IPresenter<ResponseType, FormatType> : IOutputPort<ResponseType>
    {
        public FormatType Content { get; }
    }
}
