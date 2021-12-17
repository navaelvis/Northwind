using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Northwind.Repositories.EFCore.DataContext
{
    public class NorthwindContextFactory : IDesignTimeDbContextFactory<NorthwindContext>
    {
        public NorthwindContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<NorthwindContext>();
            optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=NorthwindDB");

            return new NorthwindContext(optionBuilder.Options);
        }
    }
}