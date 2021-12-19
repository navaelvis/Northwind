using Northwind.Entities.POCOEntities;

namespace Northwind.Entities.Interfaces
{
    public interface IOrderDetailRepository
    {
        void Create(OrderDetail orderDetail);
    }
}