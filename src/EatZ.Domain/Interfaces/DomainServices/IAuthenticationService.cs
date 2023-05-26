using EatZ.Domain.DTOs;
using EatZ.Domain.Entities;

namespace EatZ.Domain.Interfaces.DomainServices
{
    public interface IAuthenticationService
    {
        Task AddUserRoleAsync(User user, string role);

        Task CreateUserAsync(string name, string email, string password);

        Task CheckPasswordAsync(User user, string password);

        Task HasUserWithEmailAsync(string email);

        Task<User> GetUserByEmailAsync(string email);
        
        Task<User> GetUserByIdAsync(string id);

        Task<AuthenticationTokenDto> GetBearerTokenAsync(User user);

        string GetUserIdFromToken();

        TokenInfoDto GetUserInfoFromToken();
    }
}
