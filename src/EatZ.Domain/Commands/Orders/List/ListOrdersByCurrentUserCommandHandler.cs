using EatZ.Domain.Commands.Orders.List;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.DomainServices;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.CrossCutting.Constants;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Orders.Update
{
    public class ListOrdersByCurrentUserCommandHandler : IRequestHandler<ListOrdersByCurrentUserCommand, IEnumerable<Order>>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IOrderRepository _orderRepository;
        private readonly INotificationContext _notificationContext;

        public ListOrdersByCurrentUserCommandHandler(IAuthenticationService authenticationService, IOrderRepository orderRepository, INotificationContext notificationContext)
        {
            _authenticationService = authenticationService;
            _orderRepository = orderRepository;
            _notificationContext = notificationContext;
        }

        public async Task<IEnumerable<Order>> Handle(ListOrdersByCurrentUserCommand request, CancellationToken cancellationToken)
        {
            var user = _authenticationService.GetUserInfoFromToken();

            if (_notificationContext.HasNotifications)
                return default;

            if (user.Role == Roles.Consumer)
                return await _orderRepository.ListOrdersByUserIdAsync(user.UserId);
            else
                return await _orderRepository.ListOrdersByAdminIdAsync(user.UserId);
        }
    }
}
