using LGM.Adapter.Repositories.Transactions;
using LGM.Adapter.Services.Transactions;

namespace LGM.Application.Services.Transactions;
public sealed class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task CommitTransactionAsync() => await _transactionRepository.CommitTransactionAsync();

    public async Task RollbackTransactionAsync() => await _transactionRepository.RollbackTransactionAsync();

    public async Task BeginTransactionAsync() => await _transactionRepository.BeginTransactionAsync();

    public void CommitTransaction() => _transactionRepository.CommitTransaction();

    public void RollbackTransaction() => _transactionRepository.RollbackTransaction();

    public void BeginTransaction() => _transactionRepository.BeginTransaction();
}

