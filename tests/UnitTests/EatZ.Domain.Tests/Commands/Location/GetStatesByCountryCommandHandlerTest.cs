using EatZ.Domain.Commands.Location.GetStatesByCountry;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;

namespace EatZ.Domain.Tests.Commands.Location
{
    public class GetStatesByCountryCommandHandlerTest
    {
        private readonly GetStatesByCountryCommandHandler _handler;

        private readonly Mock<IStateRepository> _stateRepository;

        public GetStatesByCountryCommandHandlerTest()
        {
            _stateRepository = new Mock<IStateRepository>();
            _handler = new GetStatesByCountryCommandHandler(_stateRepository.Object);
        }

        [Fact]
        public async Task Handle_Success()
        {
            _stateRepository.Setup(x => x.GetStatesByCountryIdAsync(It.IsAny<long>())).ReturnsAsync(Enumerable.Empty<State>()).Verifiable();

            var command = new GetStatesByCountryCommand();
            var result = await _handler.Handle(command, default);

            Assert.Empty(result);
            Mock.VerifyAll(_stateRepository);
        }
    }
}
