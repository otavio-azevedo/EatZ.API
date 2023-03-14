using EatZ.Domain.DTOs;
using EatZ.Domain.Interfaces.DomainServices;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Authentication.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticationTokenDto>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly INotificationContext _notificationContext;

        public LoginCommandHandler(IAuthenticationService authenticationService, INotificationContext notificationContext)
        {
            _authenticationService = authenticationService;
            _notificationContext = notificationContext;
        }

        public async Task<AuthenticationTokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _authenticationService.GetUserByEmailAsync(request.Email);

            if (user == default)
            {
                _notificationContext.AddNotification($"Verifique o e-mail informado. O e-mail {request.Email} não está vinculado a nenhuma conta.");
                return default;
            }

            await _authenticationService.CheckPasswordAsync(user, request.Password);

            if (_notificationContext.HasNotifications)
                return default;

            return await _authenticationService.GetBearerTokenAsync(user);
        }
    }
}
