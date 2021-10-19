using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Domain.Constants;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace DigitalMarket.BisunessLogic.Commands.Account
{
    public record ChangePasswordResponse : ResponseBase<ChangePasswordResponse>
    {
        public HashSet<string> IdentityErrorCodes { get; init; }

        public static ChangePasswordResponse FromIdentityErrors(IEnumerable<IdentityError> identityErrors)
        {
            return new()
            {
                Success = false,
                Code = ResponseCodes.Conflict,
                IdentityErrorCodes = identityErrors.Select(x => x.Code).ToHashSet()
            };
        }
    }
}
