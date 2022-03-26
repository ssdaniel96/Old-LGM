namespace LGM.Adapter.Repositories.Transactions;
public interface ITransactionRepository
{
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    Task BeginTransactionAsync();
    void CommitTransaction();
    void RollbackTransaction();
    void BeginTransaction();
}
