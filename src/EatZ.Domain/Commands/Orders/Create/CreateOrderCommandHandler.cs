using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.DomainServices;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.Enums;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Orders.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, long>
    {
        private readonly IStoreOfferRepository _storeOfferRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly IOrderRepository _orderRepository;
        private readonly INotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IStoreOfferRepository storeOfferRepository, IAuthenticationService authenticationService, IOrderRepository orderRepository, INotificationContext notificationContext, IUnitOfWork unitOfWork)
        {
            _storeOfferRepository = storeOfferRepository;
            _authenticationService = authenticationService;
            _orderRepository = orderRepository;
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            string clientUserId = _authenticationService.GetUserIdFromToken();

            StoreOffers offer = await _storeOfferRepository.GetOfferByIdAsync(request.OfferId);

            if (offer.QuantityAvaible == default)
            {
                _notificationContext.AddNotification("A oferta informada não está mais disponível no momento.");
                return default;
            }

            await _unitOfWork.BeginTransactionAsync();

            var order = new Order(request.StoreId,
                clientUserId,
                request.OfferId,
                DateTime.Now,
                EOrderStatus.Created,
                offer.NetUnitPrice,
                request.Quantity);

            await _orderRepository.InsertOrderAsync(order);

            if (_notificationContext.HasNotifications)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return default;
            }

            offer.DiscountQuantityAvaible(request.Quantity);

            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            return order.Id;
        }
    }
}
