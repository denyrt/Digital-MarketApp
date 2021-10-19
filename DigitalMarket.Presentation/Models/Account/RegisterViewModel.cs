using DigitalMarket.BisunessLogic.Commands.Account;
using DigitalMarket.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace DigitalMarket.Presentation.Models.Account
{
    public record RegisterViewModel
    {
        [Required(ErrorMessage = "ValidationUsernameRequired")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "ValidationUsernameLength")]
        public string Username { get; init; }

        [Required(ErrorMessage = "ValidationEmailRequired")]
        [EmailAddress(ErrorMessage = "ValidationEmail")]
        public string Email { get; init; }

        [Required(ErrorMessage = "ValidationPasswordRequired")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "ValidationPasswordLength")]
        public string Password { get; init; }

        [Required(ErrorMessage = "ValidationConfirmPasswordRequired")]
        [Compare(nameof(Password), ErrorMessage = "ValidationConfirmPassword")]
        public string ConfirmPassword { get; init; }
    }

    public static class RegisterViewModelMapper
    {
        public static RegistryCommand ToCommand(this RegisterViewModel registerModel)
        {
            return new()
            {
                Username = registerModel.Username,
                Email = registerModel.Email,
                Password = registerModel.Password
            };
        }

        public static DigitalUser ToDigitalUser(this RegisterViewModel registerViewModel)
        {
            return new()
            {
                UserName = registerViewModel.Username,
                Email = registerViewModel.Email
            };
        }
    }
}