using DigitalMarket.Application.Interfaces;
using DigitalMarket.Application.Options;
using DigitalMarket.Application.Services;
using DigitalMarket.Domain.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalMarket.Presentation.Extensions.DependencyInjection
{
    public static class MarketEmailExtensions
    {
        public static IServiceCollection AddMarketEmail(this IServiceCollection services)
        {
            services.Configure<SendGridOptions>(options =>
            {
                options.SendGridEmail = EnvironmentConstants.SendGridEmail;
                options.SendGridUser = EnvironmentConstants.SendGridUser;
                options.SendGridKey = EnvironmentConstants.SendGridKey;
            });
            services.AddScoped<IEmailSender, SendGridEmailSender>();
            return services;
        }
    }
}