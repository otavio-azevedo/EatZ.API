using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Offers.Search
{
    public class SearchOffersByCityCommandHandler : IRequestHandler<SearchOffersByCityCommand, IEnumerable<StoreOffers>>
    {
        private readonly IStoreOfferRepository _storeOfferRepository;
        private readonly INotificationContext _notificationContext;

        public SearchOffersByCityCommandHandler(IStoreOfferRepository storeOfferRepository, INotificationContext notificationContext)
        {
            _storeOfferRepository = storeOfferRepository;
            _notificationContext = notificationContext;
        }

        public async Task<IEnumerable<StoreOffers>> Handle(SearchOffersByCityCommand request, CancellationToken cancellationToken)
        {
            var stores = await _storeOfferRepository.SearchOffersByCityAsync(request.CityId);

            if (stores == default)
            {
                _notificationContext.AddNotification("Nenhuma loja encontrada para os filtros informados");
                return default;
            }

            return stores;
        }
    }
}
