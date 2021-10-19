using DigitalMarket.Data.Models;
using System.Threading.Tasks;

namespace DigitalMarket.Application.Interfaces
{
    public interface IUserHelper
    {
        Task<DigitalUser> GetCurrentUser();
    }
}