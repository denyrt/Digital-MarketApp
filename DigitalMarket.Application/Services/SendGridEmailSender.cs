using DigitalMarket.Application.Interfaces;
using DigitalMarket.Application.Options;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.Application.Services
{
    public class SendGridEmailSender : IEmailSender
    {
        public SendGridOptions Options { get; }

        public SendGridEmailSender(IOptions<SendGridOptions> sendGridOptions)
        {
            Options = sendGridOptions.Value;
        }

        public async Task<bool> SendMessageAsync(
            string email, 
            string subject, 
            string content, 
            string htmlContent, 
            CancellationToken cancellationToken)
        {
            return await ExecuteAsync(Options.SendGridKey, email, subject, content, htmlContent, cancellationToken);
        }

        public async Task<bool> ExecuteAsync(
            string apiKey, 
            string email, 
            string subject, 
            string content, 
            string htmlContent,
            CancellationToken cancellationToken)
        {
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(Options.SendGridEmail, Options.SendGridUser);
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, htmlContent);
            var response = await client.SendEmailAsync(msg, cancellationToken);
            return response.IsSuccessStatusCode;
        }
    }
}