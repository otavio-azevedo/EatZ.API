using EatZ.Domain.Entities;
using MediatR;

namespace EatZ.Domain.Commands.Location.GetCitiesByState
{
    public class GetCitiesByStateCommand : IRequest<IEnumerable<City>>
    {
        public long StateId { get; set; }
    }
}
