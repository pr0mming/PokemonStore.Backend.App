using Microsoft.Extensions.DependencyInjection;
using PokemonStore.Backend.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonStore.Backend.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {

            services.AddScoped<ApplicationDbContextInitialiser>();

            return services;

        }
    }
}
