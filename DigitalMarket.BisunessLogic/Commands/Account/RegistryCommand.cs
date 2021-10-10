using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DigitalMarket.BisunessLogic.Commands.Account
{
    public record RegistryCommand : IRequest<RegistryResponse>
    {
        [Required, DefaultValue("username")]
        public string Username { get; init; }

        [Required, DefaultValue("example@gmail.com")]
        public string Email { get; init; }

        [Required, DefaultValue("MyStrong!Passw0rd")]
        public string Password { get; init; }
    }
}
