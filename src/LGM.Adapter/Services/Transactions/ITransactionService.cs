namespace LGM.Adapter.Services.Transactions;
public interface ITransactionService
{
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    Task BeginTransactionAsync();
    void CommitTransaction();
    void RollbackTransaction();
    void BeginTransaction();
}
