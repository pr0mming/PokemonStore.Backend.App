using PokemonStore.Backend.Application.Products.Commands.EditProduct;
using PokemonStore.Backend.Domain.Entities;
using PokemonStore.Backend.Domain.Interfaces;
using PokemonStore.Backend.UnitTests.Mocks;
using Shouldly;
using Xunit;

namespace PokemonStore.Backend.UnitTests.Tests.Commands
{
    public class UpdateProductCommandTest
    {
        private readonly IProductRepository _mockProductRepository;

        public UpdateProductCommandTest()
        {
            _mockProductRepository = MockProductRepository.GetProductRepository().Object;
        }

        [Fact]
        public async Task UpdateProduct()
        {
            var handler = new UpdateProductCommandHandler(_mockProductRepository);
            var result = await handler.Handle(new UpdateProductCommand()
            {
                Id = "f4f4e3bf-afa6-4399-87b5-a3fe17572c4d"
            }, CancellationToken.None);

            result.ShouldBeOfType<ProductEntity>();
            result.ShouldNotBeNull();
        }
    }
}
