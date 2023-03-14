using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EatZ.Infra.CrossCutting.Utility.Filters.Notification
{
    public class NotificationFilter : IActionFilter
    {
        private readonly INotificationContext _notificationContext;

        public NotificationFilter(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (_notificationContext.HasNotifications)
            {
                context.Result = new UnprocessableEntityObjectResult(_notificationContext.Notifications);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Method intentionally left empty.
        }
    }
}