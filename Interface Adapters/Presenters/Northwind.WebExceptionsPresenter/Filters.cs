using Microsoft.AspNetCore.Mvc;
using Northwind.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Northwind.WebExceptionsPresenter
{
    public static class Filters
    {
        public static void Register(MvcOptions options)
        {
            options.Filters.Add(new ApiExceptionFilterAttribute(
                new Dictionary<Type, IExceptionHandler>
                {
                    { typeof(GeneralException), new GeneralExceptionHandler() },
                    { typeof(ValidationException), new ValidationExceptionHandler() }
                }
            ));
        }
    }
}
