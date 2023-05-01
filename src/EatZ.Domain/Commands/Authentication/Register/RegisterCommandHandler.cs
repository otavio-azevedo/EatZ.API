using EatZ.Domain.DTOs;
using EatZ.Domain.Interfaces.DomainServices;
using EatZ.Infra.CrossCutting.Constants;
using EatZ.Infra.CrossCutting.Utility.NotificationPattern;
using MediatR;

namespace EatZ.Domain.Commands.Authentication.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationTokenDto>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly INotificationContext _notificationContext;

        public RegisterCommandHandler(IAuthenticationService authenticationService, INotificationContext notificationContext)
        {
            _authenticationService = authenticationService;
            _notificationContext = notificationContext;
        }

        public async Task<AuthenticationTokenDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Role))
            {
                _notificationContext.AddNotification("É obrigatório informar o papel do usuário.");
                return default;
            }

            if (request.Role.ToUpper() != Roles.Company.ToUpper() && request.Role.ToUpper() != Roles.Consumer.ToUpper())
            {
                _notificationContext.AddNotification($"O papel '{request.Role}' informado não existe.");
                return default;
            }

            await _authenticationService.HasUserWithEmailAsync(request.Email);

            if (_notificationContext.HasNotifications)
                return default;

            await _authenticationService.CreateUserAsync(request.Name, request.Email, request.Password);

            if (_notificationContext.HasNotifications)
                return default;

            var user = await _authenticationService.GetUserByEmailAsync(request.Email);

            await _authenticationService.AddUserRoleAsync(user, request.Role);

            if (_notificationContext.HasNotifications)
                return default;

            return await _authenticationService.GetBearerTokenAsync(user);
        }
    }
}
