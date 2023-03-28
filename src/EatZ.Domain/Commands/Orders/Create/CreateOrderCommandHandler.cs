using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.DomainServices;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.Enums;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Orders.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, string>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IOrderRepository _orderRepository;
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IAuthenticationService authenticationService, IOrderRepository orderRepository, INotificationContext notificationContext, IUnitOfWork unitOfWork)
        {
            _authenticationService = authenticationService;
            _orderRepository = orderRepository;
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            string clientUserId = _authenticationService.GetUserIdFromToken();
            var order = new Order(request.StoreId, clientUserId, request.OfferId, DateTime.Now, EOrderStatus.Created);

            await _orderRepository.InsertOrderAsync(order);

            await _unitOfWork.SaveChangesAsync();

            if (_notificationContext.HasNotifications)
                return default;

            return order.Id;
        }
    }
}
