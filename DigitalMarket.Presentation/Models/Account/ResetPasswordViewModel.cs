using DigitalMarket.BisunessLogic.Commands.Account;
using System.ComponentModel.DataAnnotations;

namespace DigitalMarket.Presentation.Models.Account
{
    public record ResetPasswordViewModel
    {
        [Required(ErrorMessage = "EmailRequired")]
        [EmailAddress(ErrorMessage = "InvalidEmail")]
        public string Email { get; init; }

        [Required(ErrorMessage = "PasswordRequired")]
        public string Password { get; init; }

        [Required(ErrorMessage = "ConfirmPasswordRequired")]
        [Compare(nameof(Password), ErrorMessage = "ConfirmPassword")]
        public string ConfirmPassword { get; init; }

        [Required(ErrorMessage = "TokenRequired")]
        public string Token { get; init; }
    }

    public static class ResetPasswordViewModelMapping 
    {
        public static ResetPasswordCommand ToCommand(this ResetPasswordViewModel resetPasswordModel)
        {
            return new()
            {
                Email = resetPasswordModel.Email,
                Password = resetPasswordModel.Password,
                Token = resetPasswordModel.Token
            };
        }
    }
}