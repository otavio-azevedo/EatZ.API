using EatZ.Domain.Entities;
using MediatR;

namespace EatZ.Domain.Commands.Offers.List
{
    public class ListOffersByStoreCommand : IRequest<IEnumerable<StoreOffers>>
    {
        public string StoreId { get; set; }
    }
}
