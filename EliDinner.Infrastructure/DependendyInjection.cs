using System;
using EliDinner.Application.Common.Interfaces.Authentication;
using EliDinner.Application.Common.Interfaces.Persistence;
using EliDinner.Application.Common.Interfaces.Services;
using EliDinner.Infrastructure.Authentication;
using EliDinner.Infrastructure.Persistence;
using EliDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EliDinner.Infractructure
{

    public static class DependendyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));//Adds the IOptions interface where we can request the JwtSettings
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

    }

}

