using LGM.Adapter.Services.Transactions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LGM.Api.Filters;

public class TransactionFilter : ActionFilterAttribute
{
    private readonly ITransactionService _transactionService;

    public TransactionFilter(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        _transactionService.BeginTransaction();
        base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception != null)
        {
            _transactionService.RollbackTransaction();
        }
        else
        {
            _transactionService.CommitTransaction();
        }

        base.OnActionExecuted(context);
    }
}
