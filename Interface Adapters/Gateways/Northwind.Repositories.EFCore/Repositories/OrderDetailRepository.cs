using Northwind.Entities.Interfaces;
using Northwind.Entities.POCOEntities;
using Northwind.Repositories.EFCore.DataContext;

namespace Northwind.Repositories.EFCore.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        readonly NorthwindContext _context;
        public OrderDetailRepository(NorthwindContext context) => _context = context;
        public void Create(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
        }
    }
}