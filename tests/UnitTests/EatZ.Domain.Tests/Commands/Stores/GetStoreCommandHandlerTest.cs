using EatZ.Domain.Commands.Stores.Get;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;

namespace EatZ.Domain.Tests.Commands.Stores
{
    public class GetStoreCommandHandlerTest
    {
        private readonly GetStoreCommandHandler _handler;

        private readonly Mock<IStoreRepository> _storeRepository;
        private readonly INotificationContext _notificationContext;

        public GetStoreCommandHandlerTest()
        {
            _storeRepository = new Mock<IStoreRepository>();
            _notificationContext = new NotificationContext();
            _handler = new GetStoreCommandHandler(_storeRepository.Object, _notificationContext);
        }

        [Fact]
        public async Task Handle_Success()
        {
            var store = new Store(default, default, default, default, default, default, default, default, default, default, default, default, default);
            _storeRepository.Setup(x => x.GetStoreByIdAsync(It.IsAny<string>())).ReturnsAsync(store).Verifiable();

            var command = new GetStoreCommand(default);
            var result = await _handler.Handle(command, default);

            Assert.False(_notificationContext.HasNotifications);
            Assert.Equal(store, result);
            Mock.VerifyAll();
        }

        [Fact]
        public async Task Handle_Error()
        {
            _storeRepository.Setup(x => x.GetStoreByIdAsync(It.IsAny<string>())).ReturnsAsync(default(Store)).Verifiable();

            var command = new GetStoreCommand(default);
            var result = await _handler.Handle(command, default);

            Assert.True(_notificationContext.HasNotifications);
            Assert.Null(result);
            Mock.VerifyAll();
        }
    }
}
