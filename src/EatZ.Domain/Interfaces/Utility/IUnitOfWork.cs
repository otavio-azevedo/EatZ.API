namespace EatZ.Domain.Interfaces.Utility
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();

        bool HasChanges();
    }
}