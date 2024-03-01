using Moq;
using PokemonStore.Backend.Domain.Entities;
using PokemonStore.Backend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonStore.Backend.UnitTests.Mocks
{
    public static class MockProductRepository
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var mockRepository = new Mock<IProductRepository>();

            var data = new List<ProductEntity>()
            {
                new ProductEntity()
                {
                    Id = "f4f4e3bf-afa6-4399-87b5-a3fe17572c4d",
                    Name = "Charmander",
                    Description = "Charmander is a Fire type Pokémon introduced in Generation 1. It is known as the Lizard Pokémon.",
                    ImageURL = "https://img.pokemondb.net/artwork/avif/charmander.avif",
                    Price = 950,
                    IsActive= true
                }
            };

            mockRepository.Setup(c => c.GetProductsListAsync())
                .ReturnsAsync(() => data);

            mockRepository.Setup(c => c.GetProductByIdAsync(It.IsAny<string>()))
                .ReturnsAsync((string id) => data
                    .Where(product => product.Id.Equals(id)).FirstOrDefault());

            mockRepository.Setup(c => c.CreateProductAsync(It.IsAny<ProductEntity>()))
                .Callback(() => { return; });

            mockRepository.Setup(c => c.UpdateProductAsync(It.IsAny<ProductEntity>()))
                .Callback(() => { return; });

            return mockRepository;
        }
    }
}
