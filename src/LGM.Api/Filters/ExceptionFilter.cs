using LGM.Domain.Exceptions.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace LGM.Api.Filters;

public sealed class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BaseException exp)
        {
            context.Result = new ObjectResult(exp.Message) {
                StatusCode = 400
            };

            return;
        }

        context.Result = new ObjectResult("Erro interno") {
            StatusCode = (int)HttpStatusCode.InternalServerError
        };
    }
}
