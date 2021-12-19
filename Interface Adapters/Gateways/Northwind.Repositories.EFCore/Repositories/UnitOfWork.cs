using System.Threading.Tasks;
using Northwind.Entities.Interfaces;
using Northwind.Repositories.EFCore.DataContext;

namespace Northwind.Repositories.EFCore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private NorthwindContext _context;
        public UnitOfWork(NorthwindContext context) => _context = context;
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}