using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Domain.Constants;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace DigitalMarket.BisunessLogic.Commands.Account
{
    public record ResetPasswordResponse : ResponseBase<ResetPasswordResponse>
    {
        public HashSet<string> ErrorCodes { get; init; }

        public static ResetPasswordResponse FromIdentityErrors(IEnumerable<IdentityError> identityErrors)
        {
            return new()
            {
                Success = false,
                Code = ResponseCodes.Conflict,
                ErrorCodes = identityErrors.Select(x => x.Code).ToHashSet()
            };
        }
    }
}