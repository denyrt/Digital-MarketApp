using DigitalMarket.Domain.Constants;

namespace DigitalMarket.BisunessLogic.Responses
{
    public record ResponseBase
    {
        public bool Success { get; init; }
        public string Message { get; init; }

        public static ResponseBase SuccessResponse => new()
        {
            Success = true,
            Message = ResponseMessages.Success
        };
    }

    public abstract record ResponseBase<T> : ResponseBase where T : ResponseBase, new()
    {
        public static new T SuccessResponse => new()
        {
            Success = true,
            Message = ResponseMessages.Success
        };

        public static T FromError(string message) => new()
        {
            Success = false,
            Message = message
        };
    }
}
