using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Stores.Get
{
    public class GetStoreCommandHandler : IRequestHandler<GetStoreCommand, Store>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly INotificationContext _notificationContext;

        public GetStoreCommandHandler(IStoreRepository storeRepository, INotificationContext notificationContext)
        {
            _storeRepository = storeRepository;
            _notificationContext = notificationContext;
        }

        public async Task<Store> Handle(GetStoreCommand request, CancellationToken cancellationToken)
        {
            Store store = await _storeRepository.GetStoreByIdAsync(request.Id);

            if (store == default)
            {
                _notificationContext.AddNotification("Loja não encontrada.");
                return default;
            }

            return store;
        }
    }
}
