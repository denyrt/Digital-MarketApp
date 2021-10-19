using DigitalMarket.Application.Interfaces;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace DigitalMarket.BisunessLogic.Commands.Email
{
    public class SendConfirmEmailLetterCommandHandler : IRequestHandler<SendConfirmEmailLetterCommand, bool>
    {
        private readonly AspNetUserManager<DigitalUser> _aspNetUserManager;
        private readonly IEmailSender _emailSender;

        public SendConfirmEmailLetterCommandHandler(AspNetUserManager<DigitalUser> aspNetUserManager, IEmailSender emailSender)
        {
            _aspNetUserManager = aspNetUserManager;
            _emailSender = emailSender;
        }

        public async Task<bool> Handle(SendConfirmEmailLetterCommand request, CancellationToken cancellationToken)
        {
            string token = await _aspNetUserManager.GenerateEmailConfirmationTokenAsync(request.DigitalUser);
            string confirmUrl = string.Format("{0}/Account/ConfirmEmail?username={1}&token={2}",
                EnvironmentConstants.BackendHost,
                Uri.EscapeDataString(request.DigitalUser.UserName),
                Uri.EscapeDataString(token));

            return await _emailSender.SendMessageAsync(
                email: request.DigitalUser.Email,
                subject: "Email Confirmation",
                content: "Open this link in browser to confirm you mail: " + confirmUrl,
                htmlContent: $"<html><body>Click <a href=\"{confirmUrl}\">here</a> to confirm your mail.</html></body>",
                cancellationToken);
        }
    }
}
