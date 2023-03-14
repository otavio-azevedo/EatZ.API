namespace EatZ.Domain.DTOs
{
    public class AuthenticationTokenDto
    {
        public AuthenticationTokenDto(string accessToken, DateTime expiration, string userName)
        {
            AccessToken = accessToken;
            Expiration = expiration;
            UserName = userName;
        }

        public string AccessToken { get; private set; }
        public DateTime Expiration { get; private set; }
        public string UserName { get; private set; }
    }
}
