using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Offers.Search
{
    public class SearchOffersByCityCommandHandler : IRequestHandler<SearchOffersByCityCommand, IEnumerable<StoreOffers>>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IStoreOfferRepository _storeOfferRepository;
        private readonly INotificationContext _notificationContext;

        public SearchOffersByCityCommandHandler(IReviewRepository reviewRepository, IStoreOfferRepository storeOfferRepository, INotificationContext notificationContext)
        {
            _reviewRepository = reviewRepository;
            _storeOfferRepository = storeOfferRepository;
            _notificationContext = notificationContext;
        }

        public async Task<IEnumerable<StoreOffers>> Handle(SearchOffersByCityCommand request, CancellationToken cancellationToken)
        {
            var offers = await _storeOfferRepository.SearchOffersByCityAsync(request.CityId);

            if (offers == default)
            {
                _notificationContext.AddNotification("Nenhuma oferta encontrada para os filtros informados");
                return default;
            }

            var reviews = _reviewRepository.GetAverageStoreRatingByCity(request.CityId);

            foreach (var offer in offers)
                offer.Store.SetAverageReview(reviews.FirstOrDefault(x => x.StoreId == offer.StoreId) ?? new());

            return offers;
        }
    }
}
