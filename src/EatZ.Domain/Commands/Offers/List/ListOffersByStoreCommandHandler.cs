using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using MediatR;

namespace EatZ.Domain.Commands.Offers.List
{
    public class ListOffersByStoreCommandHandler : IRequestHandler<ListOffersByStoreCommand, IEnumerable<StoreOffers>>
    {
        private readonly IStoreOfferRepository _storeOfferRepository;
        
        public ListOffersByStoreCommandHandler(IStoreOfferRepository storeOfferRepository)
        {
            _storeOfferRepository = storeOfferRepository;
        }

        public async Task<IEnumerable<StoreOffers>> Handle(ListOffersByStoreCommand request, CancellationToken cancellationToken)
        {
            return await _storeOfferRepository.SearchOffersByStoreAsync(request.StoreId);
        }
    }
}
