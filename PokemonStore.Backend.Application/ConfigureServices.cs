using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PokemonStore.Backend.Application.Common.Behaviours;
using System.Reflection;

namespace PokemonStore.Backend.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
