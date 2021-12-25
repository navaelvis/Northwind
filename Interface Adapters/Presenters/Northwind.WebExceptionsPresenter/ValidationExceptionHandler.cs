using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.WebExceptionsPresenter
{
    public class ValidationExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            var exception = context.Exception as ValidationException;

            StringBuilder builder = new StringBuilder();
            foreach (var failure in exception.Errors)
            {
                builder.AppendLine($"Propiedad: {failure.PropertyName}. Error: {failure.ErrorMessage}");
            }

            return SetResult(
                context,
                StatusCodes.Status400BadRequest,
                "Error en los datos de entrada",
                builder.ToString());
        }
    }
}