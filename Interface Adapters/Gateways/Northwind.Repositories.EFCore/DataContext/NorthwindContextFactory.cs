using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Northwind.Repositories.EFCore.DataContext
{
    public class NorthwindContextFactory : IDesignTimeDbContextFactory<NorthwindContext>
    {
        public NorthwindContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<NorthwindContext>();
            optionBuilder.UseSqlServer("Server=localhost;Database=NorthwindDB;User Id=sa;Password=reallyStrongPwd123;");

            return new NorthwindContext(optionBuilder.Options);
        }
    }
}