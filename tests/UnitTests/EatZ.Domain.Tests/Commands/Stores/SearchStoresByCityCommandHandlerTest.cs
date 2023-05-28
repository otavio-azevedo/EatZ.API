using EatZ.Domain.Commands.Stores.Search;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;

namespace EatZ.Domain.Tests.Commands.Stores
{
    public class SearchStoresByCityCommandHandlerTest
    {
        private readonly SearchStoresByCityCommandHandler _handler;

        private readonly Mock<IStoreRepository> _storeRepository;
        private readonly INotificationContext _notificationContext;

        public SearchStoresByCityCommandHandlerTest()
        {
            _storeRepository = new Mock<IStoreRepository>();
            _notificationContext = new NotificationContext();
            _handler = new SearchStoresByCityCommandHandler(_storeRepository.Object, _notificationContext);
        }

        [Fact]
        public async Task Handle_Success()
        {
            var store = new Store(default, default, default, default, default, default, default, default, default, default, default, default, default);
            var stores = new List<Store> { store };
            _storeRepository.Setup(x => x.SearchStoresByCityAsync(It.IsAny<long>())).ReturnsAsync(stores).Verifiable();

            var command = new SearchStoresByCityCommand();
            var result = await _handler.Handle(command, default);

            Assert.False(_notificationContext.HasNotifications);
            Assert.Equal(stores, result);
            Mock.VerifyAll();
        }

        [Fact]
        public async Task Handle_Error()
        {
            _storeRepository.Setup(x => x.SearchStoresByCityAsync(It.IsAny<long>())).ReturnsAsync(Enumerable.Empty<Store>()).Verifiable();

            var command = new SearchStoresByCityCommand();
            var result = await _handler.Handle(command, default);

            Assert.True(_notificationContext.HasNotifications);
            Assert.Empty(result);
            Mock.VerifyAll();
        }
    }
}
