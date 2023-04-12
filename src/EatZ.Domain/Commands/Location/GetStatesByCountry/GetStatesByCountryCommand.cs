using EatZ.Domain.Entities;
using MediatR;

namespace EatZ.Domain.Commands.Location.GetStatesByCountry
{
    public class GetStatesByCountryCommand : IRequest<IEnumerable<State>>
    {
        public long CountryId { get; set; }
    }
}
