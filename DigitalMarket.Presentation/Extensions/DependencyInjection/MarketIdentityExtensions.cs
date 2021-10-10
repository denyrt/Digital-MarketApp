using DigitalMarket.Data.Contexts;
using DigitalMarket.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DigitalMarket.Presentation.Extensions.DependencyInjection
{
    public static class MarketIdentityExtensions
    {
        public static IServiceCollection AddMarketIdentity(this IServiceCollection services)
        {
            services
                .AddScoped<ISecurityStampValidator, SecurityStampValidator<DigitalUser>>()
                .AddScoped<ISystemClock, SystemClock>()
                .AddHttpContextAccessor()
                .AddIdentityCore<DigitalUser>(options => 
                {
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedEmail = true;
                })
                .AddRoles<DigitalRole>()
                .AddEntityFrameworkStores<DigitalMarketDbContext>()
                .AddUserManager<AspNetUserManager<DigitalUser>>()
                .AddRoleManager<AspNetRoleManager<DigitalRole>>()
                .AddSignInManager<SignInManager<DigitalUser>>()
                .AddDefaultTokenProviders();

            services
                .AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddCookie(IdentityConstants.ApplicationScheme, options =>
                {    
                    options.Cookie.IsEssential = true;
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                    options.SlidingExpiration = true;
                })
                .AddCookie(IdentityConstants.ExternalScheme)
                .AddCookie(IdentityConstants.TwoFactorUserIdScheme);
            
            return services;
        }
    }
}