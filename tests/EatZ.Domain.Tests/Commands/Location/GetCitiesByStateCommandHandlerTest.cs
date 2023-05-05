using EatZ.Domain.Commands.Location.GetCitiesByState;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;

namespace EatZ.Domain.Tests.Commands.Location
{
    public class GetCitiesByStateCommandHandlerTest
    {
        private readonly GetCitiesByStateCommandHandler _handler;

        private readonly Mock<ICityRepository> _cityRepository;

        public GetCitiesByStateCommandHandlerTest()
        {
            _cityRepository = new Mock<ICityRepository>();
            _handler = new GetCitiesByStateCommandHandler(_cityRepository.Object);
        }

        [Fact]
        public async Task Handle_Success()
        {
            _cityRepository.Setup(x => x.GetCitiesByStateIdAsync(It.IsAny<long>())).ReturnsAsync(Enumerable.Empty<City>()).Verifiable();

            var command = new GetCitiesByStateCommand();
            var result = await _handler.Handle(command, default);

            Assert.Empty(result);
            Mock.VerifyAll(_cityRepository);
        }
    }
}
