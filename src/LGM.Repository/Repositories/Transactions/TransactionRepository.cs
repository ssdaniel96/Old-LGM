using LGM.Adapter.Repositories.Transactions;
using LGM.Repository.Context;

namespace LGM.Repository.Repositories.Transactions;
public sealed class TransactionRepository : ITransactionRepository
{
    private readonly ApplicationDbContext _context;

    public TransactionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CommitTransactionAsync() => await _context.Database.CommitTransactionAsync();

    public async Task RollbackTransactionAsync() => await _context.Database.RollbackTransactionAsync();

    public async Task BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();

    public void CommitTransaction() => _context.Database.CommitTransaction();

    public void RollbackTransaction() => _context.Database.RollbackTransaction();

    public void BeginTransaction() => _context.Database.BeginTransaction();
}

