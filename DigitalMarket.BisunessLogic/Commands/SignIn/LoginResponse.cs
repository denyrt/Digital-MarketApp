using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Domain.Constants;

namespace DigitalMarket.BisunessLogic.Commands.SignIn
{
    public record LoginResponse : ResponseBase<LoginResponse>
    {
        public string AccessToken { get; init; }

        public static LoginResponse FromSuccess(string accessToken) => new()
        {
            Success = true,
            Code = ResponseCodes.Success,
            AccessToken = accessToken
        };
    }
}
