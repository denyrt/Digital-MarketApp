using DigitalMarket.Application.Interfaces;
using DigitalMarket.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DigitalMarket.Application.Services
{
    public class UserHelper : IUserHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AspNetUserManager<DigitalUser> _aspNetUserManager;

        public UserHelper(IHttpContextAccessor httpContextAccessor, AspNetUserManager<DigitalUser> aspNetUserManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _aspNetUserManager = aspNetUserManager;
        }

        public async Task<DigitalUser> GetCurrentUser()
        {
            var username = _httpContextAccessor.HttpContext.User.Identity.Name;
            return await _aspNetUserManager.FindByNameAsync(username);
        }
    }
}
