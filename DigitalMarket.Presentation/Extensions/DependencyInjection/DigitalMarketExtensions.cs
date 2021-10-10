using DigitalMarket.BisunessLogic.Extensions;
using DigitalMarket.BisunessLogic.Pipelines;
using DigitalMarket.Data.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace DigitalMarket.Presentation.Extensions.DependencyInjection
{
    public static class DigitalMarketExtensions
    {
        public static IServiceCollection AddDigitalMarket(this IServiceCollection services)
        {
            services.AddMarketIdentity();
            services.AddMarketLocalization();
            services.AddMarketEmail();

            services
                .AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(o => 
                {
                    o.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        return factory.Create($"Models.{type.Name}", Assembly.GetExecutingAssembly().FullName);
                    };
                });

           
            services.AddMediatR(BisunessLogicAssembly.GetAssembly());
            services.AddValidatorsFromAssembly(BisunessLogicAssembly.GetAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}