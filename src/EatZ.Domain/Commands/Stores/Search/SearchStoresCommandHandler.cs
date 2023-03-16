using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Stores.Search
{
    public class SearchStoresCommandHandler : IRequestHandler<SearchStoresCommand, IEnumerable<Store>>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly INotificationContext _notificationContext;

        public SearchStoresCommandHandler(IStoreRepository storeRepository, INotificationContext notificationContext)
        {
            _storeRepository = storeRepository;
            _notificationContext = notificationContext;
        }

        public async Task<IEnumerable<Store>> Handle(SearchStoresCommand request, CancellationToken cancellationToken)
        {
            var stores = await _storeRepository.SearchStoresAsync(request.Country, request.State, request.City, request.Neighborhood, request.Street);

            if (stores == default)
            {
                _notificationContext.AddNotification("Nenhuma loja encontrada para os filtros informados");
                return default;
            }

            return stores;
        }
    }
}
