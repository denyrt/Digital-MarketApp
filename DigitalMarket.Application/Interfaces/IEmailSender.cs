using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.Application.Interfaces
{
    public interface IEmailSender
    {
        Task<bool> SendMessageAsync(
            string email,
            string subject,
            string content,
            string htmlContent,
            CancellationToken cancellationToken);
    }
}