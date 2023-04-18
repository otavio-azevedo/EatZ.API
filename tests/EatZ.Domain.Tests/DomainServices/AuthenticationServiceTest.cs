using EatZ.Domain.DomainServices.Authentication;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.DomainServices;
using EatZ.Infra.CrossCutting.Settings;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace EatZ.Domain.Tests.DomainServices
{
    public class AuthenticationServiceTest
    {
        private readonly IOptions<JwtSettings> _jwtSettings;
        private readonly INotificationContext _notificationContext;

        public AuthenticationServiceTest()
        {
            _jwtSettings = Options.Create(new JwtSettings()
            {
                Audience = "EatZ",
                Issuer = "EatZ",
                Key = "ca297ebdf8424fe49bd0c3485bce4f45",
                Subject = "JWT for EatZ auth"
            });

            _notificationContext = new NotificationContext();
        }

        [Fact]
        public async Task GetUserByEmail_Error()
        {
            var mockUserManager = GetMockUserManager();
            IAuthenticationService _authenticationService = new AuthenticationService(Options.Create(new JwtSettings()), mockUserManager.Object, _notificationContext, default);

            var user = await _authenticationService.GetUserByEmailAsync(default);

            Assert.Null(user);
            Assert.True(_notificationContext.HasNotifications);
        }

        [Fact]
        public async Task GetUserByEmail_Success()
        {
            var mockUserManager = GetMockUserManager();
            mockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(new User());
            IAuthenticationService _authenticationService = new AuthenticationService(Options.Create(new JwtSettings()), mockUserManager.Object, _notificationContext, default);

            var user = await _authenticationService.GetUserByEmailAsync(default);

            Assert.NotNull(user);
            Assert.False(_notificationContext.HasNotifications);
        }

        [Fact]
        public async Task GetUserById_Error()
        {
            var mockUserManager = GetMockUserManager();
            IAuthenticationService _authenticationService = new AuthenticationService(Options.Create(new JwtSettings()), mockUserManager.Object, _notificationContext, default);

            var user = await _authenticationService.GetUserByIdAsync(default);

            Assert.Null(user);
            Assert.True(_notificationContext.HasNotifications);
        }

        [Fact]
        public async Task GetUserById_Success()
        {
            var mockUserManager = GetMockUserManager();
            mockUserManager.Setup(x => x.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(new User());
            IAuthenticationService _authenticationService = new AuthenticationService(Options.Create(new JwtSettings()), mockUserManager.Object, _notificationContext, default);

            var user = await _authenticationService.GetUserByIdAsync(default);

            Assert.NotNull(user);
            Assert.False(_notificationContext.HasNotifications);
        }

        [Fact]
        public async Task HasUserWithEmail_Error()
        {
            var mockUserManager = GetMockUserManager();
            mockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(new User());
            IAuthenticationService _authenticationService = new AuthenticationService(Options.Create(new JwtSettings()), mockUserManager.Object, _notificationContext, default);

            await _authenticationService.HasUserWithEmailAsync(default);

            Assert.True(_notificationContext.HasNotifications);
        }

        [Fact]
        public async Task HasUserWithEmail_Success()
        {
            var mockUserManager = GetMockUserManager();
            IAuthenticationService _authenticationService = new AuthenticationService(Options.Create(new JwtSettings()), mockUserManager.Object, _notificationContext, default);

            await _authenticationService.HasUserWithEmailAsync(default);

            Assert.False(_notificationContext.HasNotifications);
        }

        [Fact]
        public async Task AddUserRole_Error()
        {
            var mockUserManager = GetMockUserManager();
            IAuthenticationService _authenticationService = new AuthenticationService(Options.Create(new JwtSettings()), mockUserManager.Object, _notificationContext, default);

            await _authenticationService.AddUserRoleAsync(default, default);

            Assert.True(_notificationContext.HasNotifications);
        }

        [Fact]
        public async Task AddUserRole_Success()
        {
            var mockUserManager = GetMockUserManager();
            mockUserManager.Setup(x => x.AddToRoleAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            IAuthenticationService _authenticationService = new AuthenticationService(Options.Create(new JwtSettings()), mockUserManager.Object, _notificationContext, default);

            await _authenticationService.AddUserRoleAsync(default, default);

            Assert.False(_notificationContext.HasNotifications);
        }

        [Fact]
        public async Task CreateUser_Error()
        {
            var mockUserManager = GetMockUserManager();
            IAuthenticationService _authenticationService = new AuthenticationService(Options.Create(new JwtSettings()), mockUserManager.Object, _notificationContext, default);

            await _authenticationService.CreateUserAsync(default, default, default);

            Assert.True(_notificationContext.HasNotifications);
        }

        [Fact]
        public async Task CreateUser_Success()
        {
            var mockUserManager = GetMockUserManager();
            mockUserManager.Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            IAuthenticationService _authenticationService = new AuthenticationService(Options.Create(new JwtSettings()), mockUserManager.Object, _notificationContext, default);

            await _authenticationService.CreateUserAsync(default, default, default);

            Assert.False(_notificationContext.HasNotifications);
        }

        [Fact]
        public async Task CheckPassword_Error()
        {
            var mockUserManager = GetMockUserManager();
            IAuthenticationService _authenticationService = new AuthenticationService(Options.Create(new JwtSettings()), mockUserManager.Object, _notificationContext, default);

            await _authenticationService.CheckPasswordAsync(default, default);

            Assert.True(_notificationContext.HasNotifications);
        }

        [Fact]
        public async Task CheckPassword_Success()
        {
            var mockUserManager = GetMockUserManager();
            mockUserManager.Setup(x => x.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(true);
            IAuthenticationService _authenticationService = new AuthenticationService(Options.Create(new JwtSettings()), mockUserManager.Object, _notificationContext, default);

            await _authenticationService.CheckPasswordAsync(default, default);

            Assert.False(_notificationContext.HasNotifications);
        }

        [Fact]
        public async Task GetBearerToken_Error()
        {
            var mockUserManager = GetMockUserManager();
            mockUserManager.Setup(x => x.GetRolesAsync(It.IsAny<User>())).ReturnsAsync(new List<string>());
            IAuthenticationService _authenticationService = new AuthenticationService(_jwtSettings, mockUserManager.Object, _notificationContext, default);

            var token = await _authenticationService.GetBearerTokenAsync(default);

            Assert.Null(token);
            Assert.True(_notificationContext.HasNotifications);
        }

        [Fact]
        public async Task GetBearerToken_Success()
        {
            var mockUserManager = GetMockUserManager();
            mockUserManager.Setup(x => x.GetRolesAsync(It.IsAny<User>())).ReturnsAsync(new List<string>() { "Admin" });
            IAuthenticationService _authenticationService = new AuthenticationService(_jwtSettings, mockUserManager.Object, _notificationContext, default);

            var token = await _authenticationService.GetBearerTokenAsync(new User() { Name = "Name", Email = "Email" });

            Assert.NotNull(token);
            Assert.False(_notificationContext.HasNotifications);
        }

        [Fact]
        public void GetUserIdFromToken_Null()
        {
            var mockUserManager = GetMockUserManager();
            IAuthenticationService _authenticationService = new AuthenticationService(_jwtSettings, mockUserManager.Object, _notificationContext, default);

            var token = _authenticationService.GetUserIdFromToken();

            Assert.Null(token);
        }

        private static Mock<UserManager<User>> GetMockUserManager()
        {
            var store = new Mock<IUserStore<User>>();
            return new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null);
        }
    }
}