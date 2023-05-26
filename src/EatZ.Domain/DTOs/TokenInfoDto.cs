namespace EatZ.Domain.DTOs
{
    public class TokenInfoDto
    {
        public TokenInfoDto(string userId, string role)
        {
            UserId = userId;
            Role = role;
        }

        public string UserId { get; private set; }
        public string Role { get; private set; }
    }
}
