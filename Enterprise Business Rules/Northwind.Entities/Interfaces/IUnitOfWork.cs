using System.Threading.Tasks;

namespace Northwind.Entities.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}