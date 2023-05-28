using EatZ.Domain.Commands.Stores.Delete;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;

namespace EatZ.Domain.Tests.Commands.Stores
{
    public class DeleteStoreCommandHandlerTest
    {
        private readonly DeleteStoreCommandHandler _handler;

        private readonly Mock<IStoreRepository> _storeRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly INotificationContext _notificationContext;

        public DeleteStoreCommandHandlerTest()
        {
            _storeRepository = new Mock<IStoreRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _notificationContext = new NotificationContext();
            _handler = new DeleteStoreCommandHandler(_storeRepository.Object, _notificationContext, _unitOfWork.Object);
        }

        [Fact]
        public async Task Handle_Success()
        {
            var store = new Store(default, default, default, default, default, default, default, default, default, default, default, default, default);
            _storeRepository.Setup(x => x.GetStoreByIdAsync(It.IsAny<string>())).ReturnsAsync(store).Verifiable();
            _storeRepository.Setup(x => x.DeleteStore(It.IsAny<Store>())).Verifiable();
            _unitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(true).Verifiable();

            var command = new DeleteStoreCommand(default);
            await _handler.Handle(command, default);

            Assert.False(_notificationContext.HasNotifications);
            Mock.VerifyAll();
        }

        [Fact]
        public async Task Handle_Error()
        {
            _storeRepository.Setup(x => x.GetStoreByIdAsync(It.IsAny<string>())).ReturnsAsync(default(Store)).Verifiable();

            var command = new DeleteStoreCommand(default);
            await _handler.Handle(command, default);

            Assert.True(_notificationContext.HasNotifications);
            Mock.VerifyAll();
        }
    }
}
