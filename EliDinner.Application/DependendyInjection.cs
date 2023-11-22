using System;
using EliDinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace EliDinner.Application
{
	public static class DependendyInjection
	{
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }

    }
}

