using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Entities.Interfaces;
using Northwind.Repositories.EFCore.DataContext;
using Northwind.Repositories.EFCore.Repository;
using Northwind.UseCases.CreateOrder;
using Northwind.UseCases.Common.Behaviors;

namespace Northwind.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddNorthwindServices(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddDbContext<NorthwindContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("NorthwindDB")));
            serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
            serviceCollection.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddMediatR(typeof(CreateOrderInteractor));
            serviceCollection.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return serviceCollection;
        }
    }
}