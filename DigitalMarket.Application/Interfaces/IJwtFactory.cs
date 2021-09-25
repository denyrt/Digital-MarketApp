using DigitalMarket.Data.Models;

namespace DigitalMarket.Application.Interfaces
{
    public interface IJwtFactory
    {
        string GenerateJwtToken(DigitalUser digitalUser);
    }
}
