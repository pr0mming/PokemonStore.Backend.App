using PokemonStore.Backend.Domain.Entities;

namespace PokemonStore.Backend.Infrastructure.Persistence
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitialiser(ApplicationDbContext productRepository) 
        {
            _context = productRepository;
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("An error occurred while seeding the database: {0}", ex.Message));
                throw;
            }
        }

        public async Task TrySeedAsync()
        {

            // Data de Productos
            // Poblar base de datos si es necesario

            if (!_context.Products.Any())
            {
                _context.Products.AddRange(new List<ProductEntity>()
                {
                    new ProductEntity()
                    {
                        Name = "Charmander",
                        Description = "Charmander is a Fire type Pokémon introduced in Generation 1. It is known as the Lizard Pokémon.",
                        ImageURL = "https://img.pokemondb.net/artwork/avif/charmander.avif",
                        Price = 950,
                        IsActive= true
                    },
                    new ProductEntity()
                    {
                        Name = "Squirtle",
                        Description = "Squirtle is a Water type Pokémon introduced in Generation 1. It is known as the Tiny Turtle Pokémon.",
                        ImageURL = "https://img.pokemondb.net/artwork/avif/squirtle.avif",
                        Price = 750,
                        IsActive= true
                    },
                    new ProductEntity()
                    {
                        Name = "Blastoise",
                        Description = "Blastoise is a Water type Pokémon introduced in Generation 1. It is known as the Shellfish Pokémon.",
                        ImageURL = "https://img.pokemondb.net/artwork/avif/blastoise.avif",
                        Price = 12450,
                        IsActive= true
                    },
                    new ProductEntity()
                    {
                        Name = "Butterfree",
                        Description = "Butterfree is a Bug/Flying type Pokémon introduced in Generation 1. It is known as the Butterfly Pokémon.",
                        ImageURL = "https://img.pokemondb.net/artwork/avif/butterfree.avif",
                        Price = 350,
                        IsActive= true
                    },
                    new ProductEntity()
                    {
                        Name = "Pidgeotto",
                        Description = "Pidgeotto is a Normal/Flying type Pokémon introduced in Generation 1. It is known as the Bird Pokémon.",
                        ImageURL = "https://img.pokemondb.net/artwork/avif/pidgeotto.avif",
                        Price = 250,
                        IsActive= true
                    },
                    new ProductEntity()
                    {
                        Name = "Pikachu",
                        Description = "Pikachu is an Electric type Pokémon introduced in Generation 1. It is known as the Mouse Pokémon.",
                        ImageURL = "https://img.pokemondb.net/artwork/avif/pikachu.avif",
                        Price = 1200,
                        IsActive= true
                    },
                    new ProductEntity()
                    {
                        Name = "Sandshrew",
                        Description = "Sandshrew is a Ground type Pokémon introduced in Generation 1. It is known as the Mouse Pokémon.",
                        ImageURL = "https://img.pokemondb.net/artwork/avif/sandshrew.avif",
                        Price = 999,
                        IsActive= true
                    },
                    new ProductEntity()
                    {
                        Name = "Charizard",
                        Description = "Charizard is a Fire/Flying type Pokémon introduced in Generation 1. It is known as the Flame Pokémon.",
                        ImageURL = "https://img.pokemondb.net/artwork/avif/charizard.avif",
                        Price = 780,
                        IsActive= true
                    }
                });

                await _context.SaveChangesAsync();
            }

        }
    }
}
