using EatZ.Domain.Commands.Offers.Search;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;

namespace EatZ.Domain.Tests.Commands.Offers
{
    public class SearchOffersByCityCommandHandlerTest
    {
        private readonly SearchOffersByCityCommandHandler _handler;

        private readonly Mock<IReviewRepository> _reviewRepository;
        private readonly Mock<IStoreOfferRepository> _storeOfferRepository;
        private readonly INotificationContext _notificationContext;

        public SearchOffersByCityCommandHandlerTest()
        {
            _reviewRepository = new Mock<IReviewRepository>();
            _storeOfferRepository = new Mock<IStoreOfferRepository>();
            _notificationContext = new NotificationContext();
            _handler = new SearchOffersByCityCommandHandler(_reviewRepository.Object, _storeOfferRepository.Object, _notificationContext);
        }

        [Fact]
        public async Task Handle_Success()
        {
            var mockResult = new List<StoreOffers>
            {
                new StoreOffers(default, default, default, default, default, default, default, default)
            };

            _storeOfferRepository.Setup(x => x.SearchOffersByCityAsync(It.IsAny<long>())).ReturnsAsync(mockResult).Verifiable();

            var command = new SearchOffersByCityCommand();
            var result = await _handler.Handle(command, default);

            Assert.NotEmpty(result);
            Assert.False(_notificationContext.HasNotifications);
            Mock.VerifyAll();
        }

        [Fact]
        public async Task Handle_Error()
        {
            _storeOfferRepository.Setup(x => x.SearchOffersByCityAsync(It.IsAny<long>())).ReturnsAsync(Enumerable.Empty<StoreOffers>()).Verifiable();

            var command = new SearchOffersByCityCommand();
            var result = await _handler.Handle(command, default);

            Assert.Empty(result);
            Assert.True(_notificationContext.HasNotifications);
            Mock.VerifyAll();
        }
    }
}
