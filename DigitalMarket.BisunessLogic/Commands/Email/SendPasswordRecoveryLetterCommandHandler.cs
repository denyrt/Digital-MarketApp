using DigitalMarket.Application.Interfaces;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.Email
{
    public class SendPasswordRecoveryLetterCommandHandler : IRequestHandler<SendPasswordRecoveryLetterCommand, bool>
    {
        private readonly IEmailSender _emailSender;
        private readonly AspNetUserManager<DigitalUser> _aspNetUserManager;

        public SendPasswordRecoveryLetterCommandHandler(
            IEmailSender emailSender,
            AspNetUserManager<DigitalUser> aspNetUserManager)
        {
            _emailSender = emailSender;
            _aspNetUserManager = aspNetUserManager;
        }

        public async Task<bool> Handle(SendPasswordRecoveryLetterCommand request, CancellationToken cancellationToken)
        {
            DigitalUser user = await _aspNetUserManager.FindByEmailAsync(request.Email);
            
            if (user == null)
            {
                return false;
            }

            string token = await _aspNetUserManager.GeneratePasswordResetTokenAsync(user);
            string resetPasswordUrl = string.Format("{0}/Sign-In/ResetPassword?email={1}&token={2}",
                EnvironmentConstants.BackendHost,
                Uri.EscapeDataString(user.Email),
                Uri.EscapeDataString(token));

            return await _emailSender.SendMessageAsync(
                email: user.Email,
                subject: "Reset Password",
                content: "Open this link in your browser to reset your password: " + resetPasswordUrl,
                htmlContent: $"<html><body>Click <a href=\"{resetPasswordUrl}\">here</a> to reset your password.</html></body>",
                cancellationToken);
        }
    }
}
