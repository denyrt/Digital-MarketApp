using DigitalMarket.BisunessLogic.Commands.Account;
using System.ComponentModel.DataAnnotations;

namespace DigitalMarket.Presentation.Models.Account
{
    public record LoginViewModel
    {
        [Required(ErrorMessage = "UsernameRequired")]
        public string Username { get; init; }

        [Required(ErrorMessage = "PasswordRequired")]
        public string Password { get; init; }

        public bool RememberMe { get; init; }
    }

    public static class LoginViewModelMapper
    {
        public static LoginCommand ToCommand(this LoginViewModel loginModel)
        {
            return new()
            {
                Username = loginModel.Username,
                Password = loginModel.Password,
                RememberMe = loginModel.RememberMe
            };
        }
    }
}