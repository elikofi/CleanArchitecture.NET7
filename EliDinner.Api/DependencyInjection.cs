using System;
using EliDinner.Api.Common.Mapping;
using EliDinner.Api.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EliDinner.Api
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPresentation(this IServiceCollection services)
		{
            services.AddControllers();

            //error handling with custom problem details factory.
            services.AddSingleton<ProblemDetailsFactory, EliDinnerProblemDetailsFactory>();



            services.AddMappings();
			return services;
		}
	}
}

