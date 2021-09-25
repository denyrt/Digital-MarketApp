using DigitalMarket.Application.Interfaces;
using DigitalMarket.Application.Services;
using DigitalMarket.BisunessLogic.Extensions;
using DigitalMarket.BisunessLogic.Pipelines;
using DigitalMarket.Data.Contexts;
using DigitalMarket.Data.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace DigitalMarket.Extensions
{
    public static class DepencyInjectionExtensions
    {
        public static IServiceCollection AddDigitalMarket(this IServiceCollection services)
        {
            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });

            services
                .AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("uk")
                };

                options.DefaultRequestCulture = new RequestCulture(supportedCultures[0]);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            services
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
                .AddDefaultTokenProviders();
            
            services.AddMediatR(BisunessLogicAssembly.GetAssembly());
            services.AddValidatorsFromAssembly(BisunessLogicAssembly.GetAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped<IJwtFactory, JwtFactory>();
            
            return services;
        }
    }
}
