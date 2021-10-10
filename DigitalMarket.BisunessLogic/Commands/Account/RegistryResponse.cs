using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Domain.Constants;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace DigitalMarket.BisunessLogic.Commands.Account
{
    public record RegistryResponse : ResponseBase<RegistryResponse>
    {
        public HashSet<string> ErrorCodes { get; init; }

        public static RegistryResponse FromIdentityErrors(IEnumerable<IdentityError> identityResult)
        {
            return new()
            {
                Success = false,
                Code = ResponseCodes.Conflict,
                ErrorCodes = identityResult.Select(x => x.Code).ToHashSet()
            };
        }
    }
}