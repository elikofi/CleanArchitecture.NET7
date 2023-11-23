using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EliDinner.Application
{
	public static class DependendyInjection
	{
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependendyInjection).Assembly);
            return services;
        }

    }
}

