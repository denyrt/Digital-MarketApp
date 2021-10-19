using System.ComponentModel.DataAnnotations;

namespace DigitalMarket.Presentation.Models.Account
{
    public record ChangePasswordViewModel
    {
        [Required]
        public string CurrentPassword { get; init; }

        [Required]
        public string NewPassword { get; init; }

        [Required]
        [Compare(nameof(NewPassword))]
        public string ConfirmNewPassword { get; init; }
    }

    public static class ChangePasswordViewModelMapping
    {

    }
}
