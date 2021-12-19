using System.Collections.Generic;
using Northwind.Entities.POCOEntities;
using Northwind.Entities.Specifications;

namespace Northwind.Entities.Interfaces
{
    public interface IOrderRepository
    {
        void Create(Order order);
        IEnumerable<Order> GetOrderBySpecification(Specification<Order> specification);
    }
}