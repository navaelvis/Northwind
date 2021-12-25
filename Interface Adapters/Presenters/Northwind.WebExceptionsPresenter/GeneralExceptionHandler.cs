using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Northwind.Entities.Exceptions;
using System;
using System.Threading.Tasks;

namespace Northwind.WebExceptionsPresenter
{
    public class GeneralExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            var exception = context.Exception as GeneralException;

            return SetResult(
                context,
                StatusCodes.Status500InternalServerError,
                exception.Message,
                exception.Details);
        }
    }
}