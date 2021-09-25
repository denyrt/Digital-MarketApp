using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DigitalMarket.BisunessLogic.Commands.SignIn
{
    public record LoginCommand : IRequest<LoginResponse>
    {
        [Required, DefaultValue("username")]
        public string Username { get; init; }
        
        [Required, DefaultValue("password")]
        public string Password { get; init; }
    }
}
