using EatZ.Domain.Commands.Stores.Create;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.DomainServices;
using EatZ.Domain.Interfaces.ExternalServices;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;

namespace EatZ.Domain.Tests.Commands.Stores
{
    public class CreateStoreCommandHandlerTest
    {
        private readonly CreateStoreCommandHandler _handler;

        private readonly Mock<IStoreRepository> _storeRepository;
        private readonly Mock<IAuthenticationService> _authenticationService;
        private readonly Mock<IGoogleGeocodingApi> _googleGeocodingApi;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly INotificationContext _notificationContext;

        public CreateStoreCommandHandlerTest()
        {
            _storeRepository = new Mock<IStoreRepository>();
            _authenticationService = new Mock<IAuthenticationService>();
            _googleGeocodingApi = new Mock<IGoogleGeocodingApi>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _notificationContext = new NotificationContext();
            _handler = new CreateStoreCommandHandler(_storeRepository.Object, _authenticationService.Object, _googleGeocodingApi.Object, _notificationContext, _unitOfWork.Object);
        }

        [Fact]
        public async Task Handle_Success()
        {
            string userId = Guid.NewGuid().ToString();
            _authenticationService.Setup(x => x.GetUserIdFromToken()).Returns(userId).Verifiable();
            _authenticationService.Setup(x => x.GetUserByIdAsync(userId)).ReturnsAsync(new User()).Verifiable();
            _googleGeocodingApi.Setup(x => x.GetCoordinatesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new DTOs.GetCoordinatesDto(default, default)).Verifiable();
            _storeRepository.Setup(x => x.InsertStoreAsync(It.IsAny<Store>())).Returns(Task.CompletedTask).Verifiable();
            _unitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(true).Verifiable();

            var command = new CreateStoreCommand(default, default, default, default, default, default, default, default, default, default, string.Empty);
            var result = await _handler.Handle(command, default);

            Assert.NotNull(result);
            Assert.False(_notificationContext.HasNotifications);
            Mock.VerifyAll();
        }
    }
}
