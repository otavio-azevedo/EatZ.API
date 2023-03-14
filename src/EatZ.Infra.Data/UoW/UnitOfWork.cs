using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using EatZ.Infra.Data.Context;

namespace EatZ.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EatzDbContext _context;

        private readonly INotificationContext _notificationContext;

        public UnitOfWork(EatzDbContext context, INotificationContext notificationContext)
        {
            _context = context;
            _notificationContext = notificationContext;
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await Task.Run(() => _context.Database.CommitTransaction());
        }

        public async Task RollbackTransactionAsync()
        {
            await Task.Run(() => _context.Database.RollbackTransaction());
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (_notificationContext.HasNotifications)
            {
                return false;
            }

            await _context.SaveChangesAsync();

            return true;
        }

        public bool HasChanges()
            => _context.ChangeTracker.HasChanges();

    }
}