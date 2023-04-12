using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using MediatR;

namespace EatZ.Domain.Commands.Location.GetCitiesByState
{
    public class GetCitiesByStateCommandHandler : IRequestHandler<GetCitiesByStateCommand, IEnumerable<City>>
    {
        private readonly ICityRepository _cityRepository;

        public GetCitiesByStateCommandHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<City>> Handle(GetCitiesByStateCommand request, CancellationToken cancellationToken)
        {
            return await _cityRepository.GetCitiesByStateIdAsync(request.StateId);
        }
    }
}
