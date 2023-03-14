namespace EatZ.Infra.CrossCutting.Utility.NotificationPattern
{
    public interface INotificationContext
    {
        void AddNotification(string message);

        void ClearNotifications();

        bool HasNotifications { get; }

        IReadOnlyCollection<NotificationModel> Notifications { get; }
    }
}