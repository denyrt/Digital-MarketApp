using DigitalMarket.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.Email
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, bool>
    {
        private readonly AspNetUserManager<DigitalUser> _aspNetUserManager;

        public ConfirmEmailCommandHandler(AspNetUserManager<DigitalUser> aspNetUserManager)
        {
            _aspNetUserManager = aspNetUserManager;
        }

        public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            DigitalUser user = await _aspNetUserManager.FindByNameAsync(request.Username);
            if (user == null) return false;
            IdentityResult result = await _aspNetUserManager.ConfirmEmailAsync(user, request.Token);
            return result.Succeeded;
        }
    }
}