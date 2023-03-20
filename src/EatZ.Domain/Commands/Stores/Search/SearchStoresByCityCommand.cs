using EatZ.Domain.Entities;
using MediatR;

namespace EatZ.Domain.Commands.Stores.Search
{
    public class SearchStoresByCityCommand : IRequest<IEnumerable<Store>>
    {
        public long CityId { get; set; }
    }
}
