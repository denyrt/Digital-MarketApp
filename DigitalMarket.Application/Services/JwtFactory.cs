using DigitalMarket.Application.Interfaces;
using DigitalMarket.Data.Models;

namespace DigitalMarket.Application.Services
{
    public class JwtFactory : IJwtFactory
    {
        public string GenerateJwtToken(DigitalUser digitalUser)
        {
            return "NOT_IMPLEMENTED_JWT";
        }
    }
}
