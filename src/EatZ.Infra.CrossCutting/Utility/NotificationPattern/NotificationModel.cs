namespace EatZ.Infra.CrossCutting.Utility.NotificationPattern
{
    public class NotificationModel
    {
        public string Message { get; }

        public NotificationModel(string message)
        {
            Message = message;
        }
    }
}
