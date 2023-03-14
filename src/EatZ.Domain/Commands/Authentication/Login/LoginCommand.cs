using EatZ.Domain.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EatZ.Domain.Commands.Authentication.Login
{
    public class LoginCommand : IRequest<AuthenticationTokenDto>
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo {0} está no formado invalido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
