using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace EatZ.Domain.Commands.Stores.Search
{
    public class SearchStoresByCityCommandHandler : IRequestHandler<SearchStoresByCityCommand, IEnumerable<Store>>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly INotificationContext _notificationContext;

        public SearchStoresByCityCommandHandler(IStoreRepository storeRepository, INotificationContext notificationContext)
        {
            _storeRepository = storeRepository;
            _notificationContext = notificationContext;
        }

        public async Task<IEnumerable<Store>> Handle(SearchStoresByCityCommand request, CancellationToken cancellationToken)
        {
            var stores = await _storeRepository.SearchStoresByCityAsync(request.CityId);

            if (stores.IsNullOrEmpty())
            {
                _notificationContext.AddNotification("Nenhuma loja encontrada para os filtros informados");
                return Enumerable.Empty<Store>();
            }

            return stores;
        }
    }
}
