using System;
using EliDinner.Application.Authentication.Commands.Register;
using EliDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using EliDinner.Application.Common.Behaviours;
using FluentValidation;
using System.Reflection;

namespace EliDinner.Application
{
	public static class DependendyInjection
	{
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependendyInjection).Assembly);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));


            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }

    }
}

