using EatZ.Domain.Entities;
using MediatR;

namespace EatZ.Domain.Commands.Offers.Search
{
    public class SearchOffersByCityCommand : IRequest<IEnumerable<StoreOffers>>
    {
        public long CityId { get; set; }
    }
}
