using EatZ.Domain.Commands.Authentication.Refresh;
using EatZ.Domain.DTOs;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.DomainServices;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;

namespace EatZ.Domain.Tests.Commands.Authentication
{
    public class RefreshTokenCommandHandlerTest
    {
        private readonly RefreshTokenCommandHandler _handler;

        private readonly Mock<IAuthenticationService> _authenticationService;
        private readonly INotificationContext _notificationContext;

        public RefreshTokenCommandHandlerTest()
        {
            _authenticationService = new Mock<IAuthenticationService>();
            _notificationContext = new NotificationContext();
            _handler = new RefreshTokenCommandHandler(_authenticationService.Object, _notificationContext);
        }


        [Fact]
        public async Task Handle_Success()
        {
            var user = new User();
            _authenticationService.Setup(x => x.GetUserIdFromToken()).Returns(Guid.NewGuid().ToString()).Verifiable();
            _authenticationService.Setup(x => x.GetUserByIdAsync(It.IsAny<string>())).ReturnsAsync(user).Verifiable();
            _authenticationService.Setup(x => x.GetBearerTokenAsync(It.IsAny<User>())).ReturnsAsync(new AuthenticationTokenDto(default, default, default)).Verifiable();

            var command = new RefreshTokenCommand();
            var result = await _handler.Handle(command, default);

            Assert.False(_notificationContext.HasNotifications);
            Assert.NotNull(result);
            Mock.VerifyAll();
        }

        [Fact]
        public async Task Handle_Error()
        {
            var command = new RefreshTokenCommand();
            var result = await _handler.Handle(command, default);

            Assert.True(_notificationContext.HasNotifications);
            Assert.Null(result);
            Mock.VerifyAll();
        }
    }
}
