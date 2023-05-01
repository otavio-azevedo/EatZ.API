using EatZ.Domain.Commands.Authentication.Register;
using EatZ.Domain.DTOs;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.DomainServices;
using EatZ.Infra.CrossCutting.Constants;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;

namespace EatZ.Domain.Tests.Commands.Authentication
{
    public class RegisterCommandHandlerTest
    {
        private readonly RegisterCommandHandler _handler;

        private readonly Mock<IAuthenticationService> _authenticationService;
        private readonly INotificationContext _notificationContext;

        public RegisterCommandHandlerTest()
        {
            _authenticationService = new Mock<IAuthenticationService>();
            _notificationContext = new NotificationContext();
            _handler = new RegisterCommandHandler(_authenticationService.Object, _notificationContext);
        }


        [Fact]
        public async Task Handle_Success()
        {
            var user = new User();
            _authenticationService.Setup(x => x.HasUserWithEmailAsync(It.IsAny<string>())).Returns(Task.CompletedTask).Verifiable();
            _authenticationService.Setup(x => x.CreateUserAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.CompletedTask).Verifiable();
            _authenticationService.Setup(x => x.GetUserByEmailAsync(It.IsAny<string>())).ReturnsAsync(user).Verifiable();
            _authenticationService.Setup(x => x.AddUserRoleAsync(It.IsAny<User>(), It.IsAny<string>())).Returns(Task.CompletedTask).Verifiable();
            _authenticationService.Setup(x => x.GetBearerTokenAsync(It.IsAny<User>())).ReturnsAsync(new AuthenticationTokenDto(default, default, default)).Verifiable();

            var command = new RegisterCommand() { Role = Roles.Company };
            var result = await _handler.Handle(command, default);

            Assert.False(_notificationContext.HasNotifications);
            Assert.NotNull(result);
            Mock.VerifyAll();
        }

        [Fact]
        public async Task Handle_Error_NullOrEmptyRole()
        {
            var command = new RegisterCommand();
            var result = await _handler.Handle(command, default);

            Assert.True(_notificationContext.HasNotifications);
            Assert.Null(result);
        }

        [Fact]
        public async Task Handle_Error_NonexistentRole()
        {
            var command = new RegisterCommand() { Role = "Nonexistent" };
            var result = await _handler.Handle(command, default);

            Assert.True(_notificationContext.HasNotifications);
            Assert.Null(result);
        }
    }
}
