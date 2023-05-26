using EatZ.Domain.DTOs;
using EatZ.Domain.Interfaces.DomainServices;
using EatZ.Infra.CrossCutting.Settings;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using EatZ.Infra.CrossCutting.Constants;
using EatZ.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace EatZ.Domain.DomainServices.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<User> _userManager;
        private readonly INotificationContext _notificationContext;
        private readonly IHttpContextAccessor _httpContext;

        public AuthenticationService(IOptions<JwtSettings> jwtSettings, UserManager<User> userManager, INotificationContext notificationContext, IHttpContextAccessor httpContext)
        {
            _jwtSettings = jwtSettings.Value;
            _userManager = userManager;
            _notificationContext = notificationContext;
            _httpContext = httpContext;
        }

        public async Task CreateUserAsync(string name, string email, string password)
        {
            var result = await _userManager.CreateAsync(
            user: new User()
            {
                Name = name,
                CreationDate = DateTime.Now,
                UserName = email,
                Email = email,
                EmailConfirmed = true,
            },
            password: password);

            if (result == default || !result.Succeeded)
            {
                _notificationContext.AddNotification("Não foi possível criar o usuário neste momento.");
            }
        }

        public async Task AddUserRoleAsync(User user, string role)
        {
            var result = await _userManager.AddToRoleAsync(user, role);

            if (result == default || !result.Succeeded)
            {
                _notificationContext.AddNotification("Não foi possível adicionar a role ao usuário.");
            }
        }

        public async Task HasUserWithEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != default)
            {
                _notificationContext.AddNotification("Já existe um usuário com esse email cadastrado.");
            }
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == default)
            {
                _notificationContext.AddNotification("Usuário não encontrado.");
            }

            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == default)
            {
                _notificationContext.AddNotification("Usuário não encontrado.");
            }

            return user;
        }

        public async Task CheckPasswordAsync(User user, string password)
        {
            bool isValidPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!isValidPassword)
            {
                _notificationContext.AddNotification("A senha informada está incorreta.");
            }
        }

        public string GetUserIdFromToken()
        {
            return _httpContext?.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == Claims.UserId)?.Value;
        }

        public TokenInfoDto GetUserInfoFromToken()
        {
            var userId = GetUserIdFromToken();
            var role = _httpContext?.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == Claims.Role)?.Value;
            
            return new TokenInfoDto(userId, role);
        }

        public async Task<AuthenticationTokenDto> GetBearerTokenAsync(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            if (userRoles.IsNullOrEmpty())
            {
                _notificationContext.AddNotification($"O usuario {user?.Name} não possui nenhuma role associada.");
                return default;
            }
            
            DateTime expiration = DateTime.Now.AddMinutes(60);

            var token = CreateJwtToken(
                CreateClaims(user, userRoles.First()),
                CreateSigningCredentials(),
                expiration
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            string accessToken = tokenHandler.WriteToken(token);

            return new AuthenticationTokenDto(accessToken, expiration, user.Name);
        }

        private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration) =>
            new(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: expiration,
                signingCredentials: credentials
            );

        private Claim[] CreateClaims(User user, string userRole) =>
           new[] {
                new Claim(Claims.Role, userRole),
                new Claim(JwtRegisteredClaimNames.Sub, _jwtSettings.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(Claims.UserId, user.Id),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
           };

        private SigningCredentials CreateSigningCredentials() =>
            new(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.Key)
                ),
                SecurityAlgorithms.HmacSha256
            );
    }
}
