using DigitalMarket.BisunessLogic.Commands.Email;
using System.ComponentModel.DataAnnotations;

namespace DigitalMarket.Presentation.Models.Account
{
    public record ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; init; }
    }

    public static class ForgotPasswordViewModelMapping
    {
        public static SendPasswordRecoveryLetterCommand ToCommand(this ForgotPasswordViewModel forgotPasswordModel)
        {
            return new()
            {
                Email = forgotPasswordModel.Email
            };
        }
    }
}