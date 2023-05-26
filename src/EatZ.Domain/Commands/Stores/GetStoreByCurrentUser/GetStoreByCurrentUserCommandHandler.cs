using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.DomainServices;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Stores.GetStoreByCurrentUser
{
    public class GetStoreByCurrentUserCommandHandler : IRequestHandler<GetStoreByCurrentUserCommand, Store>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IStoreRepository _storeRepository;
        private readonly INotificationContext _notificationContext;

        public GetStoreByCurrentUserCommandHandler(IAuthenticationService authenticationService, IStoreRepository storeRepository, INotificationContext notificationContext)
        {
            _authenticationService = authenticationService;
            _storeRepository = storeRepository;
            _notificationContext = notificationContext;
        }

        public async Task<Store> Handle(GetStoreByCurrentUserCommand request, CancellationToken cancellationToken)
        {
            var userId = _authenticationService.GetUserIdFromToken();

            if (_notificationContext.HasNotifications)
                return default;

            Store store = await _storeRepository.GetStoreByAdminIdAsync(userId);

            if (store == default)
            {
                _notificationContext.AddNotification("Loja não encontrada.");
                return default;
            }

            return store;
        }
    }
}
