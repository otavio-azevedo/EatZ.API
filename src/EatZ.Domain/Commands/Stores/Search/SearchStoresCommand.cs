using EatZ.Domain.Entities;
using MediatR;

namespace EatZ.Domain.Commands.Stores.Search
{
    public class SearchStoresCommand : IRequest<IEnumerable<Store>>
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
    }
}
