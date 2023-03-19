using EatZ.Domain.Entities;
using EatZ.Infra.CrossCutting.Utility.Pagination;
using MediatR;

namespace EatZ.Domain.Commands.Location.SearchCities
{
    public class SearchCitiesCommand : OffsetPagedRequest, IRequest<IEnumerable<City>>
    {
        public string CityName { get; set; }
    }
}
