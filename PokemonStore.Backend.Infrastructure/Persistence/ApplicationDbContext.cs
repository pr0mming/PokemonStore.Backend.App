using Microsoft.EntityFrameworkCore;
using PokemonStore.Backend.Domain.Entities;
using System.Reflection;

namespace PokemonStore.Backend.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }

        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<OrderEntity> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

    }
}
