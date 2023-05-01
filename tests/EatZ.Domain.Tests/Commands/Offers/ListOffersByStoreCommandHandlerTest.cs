using EatZ.Domain.Commands.Offers.List;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;

namespace EatZ.Domain.Tests.Commands.Offers
{
    public class ListOffersByStoreCommandHandlerTest
    {
        private readonly ListOffersByStoreCommandHandler _handler;

        private readonly Mock<IStoreOfferRepository> _storeOfferRepository;

        public ListOffersByStoreCommandHandlerTest()
        {
            _storeOfferRepository = new Mock<IStoreOfferRepository>();
            _handler = new ListOffersByStoreCommandHandler(_storeOfferRepository.Object);
        }

        [Fact]
        public async Task Handle_Success()
        {
            _storeOfferRepository.Setup(x => x.SearchOffersByStoreAsync(It.IsAny<string>())).ReturnsAsync(Enumerable.Empty<StoreOffers>()).Verifiable();
            var command = new ListOffersByStoreCommand();
            var result = await _handler.Handle(command, default);

            Assert.Empty(result);
            Mock.VerifyAll();
        }
    }
}

