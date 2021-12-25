using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Northwind.WebExceptionsPresenter
{
    public interface IExceptionHandler
    {
        Task Handle(ExceptionContext context);
    }
}