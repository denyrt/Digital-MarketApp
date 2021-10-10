using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Domain.Constants;
using Microsoft.AspNetCore.Identity;

namespace DigitalMarket.BisunessLogic.Commands.Account
{
    public record LoginResponse : ResponseBase<LoginResponse>
    {
        public static LoginResponse FromSignInResult(SignInResult signInResult)
        {
            if (signInResult.Succeeded)
            {
                return new()
                {
                    Success = true,
                    Code = ResponseCodes.Ok
                };
            }

            if (signInResult.IsNotAllowed)
            {
                return new()
                {
                    Success = false,
                    Code = ResponseCodes.EmailNotConfirmed
                };
            }

            return new()
            {
                Success = false,
                Code = ResponseCodes.InvalidCredentials
            };
        }
    }
}