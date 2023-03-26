using EatZ.Domain.DTOs;
using MediatR;

namespace EatZ.Domain.Commands.Authentication.Refresh
{
    public class RefreshTokenCommand : IRequest<AuthenticationTokenDto>
    {
    }
}
