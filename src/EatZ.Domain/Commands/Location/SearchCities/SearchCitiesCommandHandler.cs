using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Location.SearchCities
{
    public class SearchCitiesCommandHandler : IRequestHandler<SearchCitiesCommand, IEnumerable<City>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly INotificationContext _notificationContext;

        public SearchCitiesCommandHandler(ICityRepository cityRepository, INotificationContext notificationContext)
        {
            _cityRepository = cityRepository;
            _notificationContext = notificationContext;
        }

        public async Task<IEnumerable<City>> Handle(SearchCitiesCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<City> result = await _cityRepository.SearchCitiesByNameAsync(request.CityName, request.Offset, request.Limit);

            if (result == default)
            {
                _notificationContext.AddNotification("Nenhuma cidade localizada, tente novamente.");
                return Enumerable.Empty<City>();
            }

            return result;
        }
    }
}