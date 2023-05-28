using EatZ.Domain.Commands.Location.SearchCities;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;

namespace EatZ.Domain.Tests.Commands.Location
{
    public class SearchCitiesCommandHandlerTest
    {
        private readonly SearchCitiesCommandHandler _handler;

        private readonly Mock<ICityRepository> _cityRepository;
        private readonly INotificationContext _notificationContext;

        public SearchCitiesCommandHandlerTest()
        {
            _cityRepository = new Mock<ICityRepository>();
            _notificationContext = new NotificationContext();
            _handler = new SearchCitiesCommandHandler(_cityRepository.Object, _notificationContext);
        }

        [Fact]
        public async Task Handle_Success()
        {
            var mockResult = new List<City>
            {
                new City(default, default, default, default)
            };

            _cityRepository.Setup(x => x.SearchCitiesByNameAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(mockResult).Verifiable();

            var command = new SearchCitiesCommand();
            var result = await _handler.Handle(command, default);

            Assert.NotEmpty(result);
            Assert.False(_notificationContext.HasNotifications);
            Mock.VerifyAll(_cityRepository);
        }

        [Fact]
        public async Task Handle_Error()
        {
            _cityRepository.Setup(x => x.SearchCitiesByNameAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(Enumerable.Empty<City>()).Verifiable();

            var command = new SearchCitiesCommand();
            var result = await _handler.Handle(command, default);

            Assert.Empty(result);
            Assert.True(_notificationContext.HasNotifications);
            Mock.VerifyAll(_cityRepository);
        }
    }
}
