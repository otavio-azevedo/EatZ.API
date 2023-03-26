using EatZ.Domain.DTOs;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.DomainServices;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Authentication.Refresh
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthenticationTokenDto>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly INotificationContext _notificationContext;

        public RefreshTokenCommandHandler(IAuthenticationService authenticationService, INotificationContext notificationContext)
        {
            _authenticationService = authenticationService;
            _notificationContext = notificationContext;
        }

        public async Task<AuthenticationTokenDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            string userId = _authenticationService.GetUserIdFromToken();

            if (string.IsNullOrEmpty(userId))
            {
                _notificationContext.AddNotification("Token inválido.");
                return default;
            }

            User user = await _authenticationService.GetUserByIdAsync(userId);

            if (_notificationContext.HasNotifications)
                return default;

            return await _authenticationService.GetBearerTokenAsync(user);
        }
    }
}
