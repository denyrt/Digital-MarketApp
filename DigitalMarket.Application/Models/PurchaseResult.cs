using DigitalMarket.Data.Models;

namespace DigitalMarket.Application.Models
{
    public record PurchaseResult
    {
        public bool Success { get; init; }
        public string ErrorMessage { get; init; }
        public DigitalItem Drop { get; init; }

        public static PurchaseResult FromError(string message)
        {
            return new()
            {
                Success = true,
                ErrorMessage = message
            };
        }

        public static PurchaseResult FromSuccess(DigitalItem digitalItem)
        {
            return new() 
            { 
                Success = true,
                Drop = digitalItem
            };
        }
    }

    public static class PurchaseMessages
    {
        public const string LowBalance = "LowBalance";
        public const string Unavailable = "Unavailable";
    }
}
