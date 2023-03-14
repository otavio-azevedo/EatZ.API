
namespace EatZ.Infra.CrossCutting.Utility.NotificationPattern
{
    public class NotificationContext : INotificationContext
    {
        private readonly List<NotificationModel> _notifications;

        public IReadOnlyCollection<NotificationModel> Notifications => _notifications;

        public bool HasNotifications => _notifications.Any();

        public NotificationContext()
        {
            _notifications = new List<NotificationModel>();
        }

        public void AddNotification(string message)
        {
            _notifications.Add(new NotificationModel(message));
        }

        public void ClearNotifications()
        {
            _notifications.Clear();
        }
    }
}