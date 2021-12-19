using System.Collections.Generic;
using System.Linq;
using Northwind.Entities.Interfaces;
using Northwind.Entities.POCOEntities;
using Northwind.Entities.Specifications;
using Northwind.Repositories.EFCore.DataContext;

namespace Northwind.Repositories.EFCore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        readonly NorthwindContext _context;
        public OrderRepository(NorthwindContext context) => _context = context;
        public void Create(Order order)
        {
            _context.Add(order);
        }

        public IEnumerable<Order> GetOrderBySpecification(Specification<Order> specification)
        {
            var expressionDelegate = specification.Expression.Compile();
            return _context.Orders.Where(expressionDelegate);
        }
    }
}