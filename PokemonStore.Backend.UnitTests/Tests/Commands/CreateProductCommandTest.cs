using PokemonStore.Backend.Application.Products.Commands.CreateProduct;
using PokemonStore.Backend.Domain.Entities;
using PokemonStore.Backend.Domain.Interfaces;
using PokemonStore.Backend.UnitTests.Mocks;
using Shouldly;
using Xunit;

namespace PokemonStore.Backend.UnitTests.Tests.Commands
{
    public class CreateProductCommandTest
    {
        private readonly IProductRepository _mockProductRepository;

        public CreateProductCommandTest()
        {
            _mockProductRepository = MockProductRepository.GetProductRepository().Object;
        }

        [Fact]
        public async Task CreateProduct()
        {
            var handler = new CreateProductCommandHandler(_mockProductRepository);
            var result = await handler.Handle(new CreateProductCommand()
            {
                Name = "Test Pokemon",
                Description = "Test for Description",
                Price = 100
            }, CancellationToken.None);

            result.ShouldBeOfType<ProductEntity>();
            result.ShouldNotBeNull();
        }
    }
}
