using PokemonStore.Backend.Application.Products.Queries.GetProductById;
using PokemonStore.Backend.Domain.Entities;
using PokemonStore.Backend.Domain.Interfaces;
using PokemonStore.Backend.UnitTests.Mocks;
using Shouldly;
using Xunit;

namespace PokemonStore.Backend.UnitTests.Tests.Queries
{
    public class GetProductByIdQueryTest
    {
        private readonly IProductRepository _mockProductRepository;

        public GetProductByIdQueryTest()
        {
            _mockProductRepository = MockProductRepository.GetProductRepository().Object;
        }

        [Fact]
        public async Task GetProductById()
        {
            var handler = new GetProductByIdQueryHandler(_mockProductRepository);
            var result = await handler.Handle(new GetProductByIdQuery()
            {
                Id = "f4f4e3bf-afa6-4399-87b5-a3fe17572c4d"
            }, CancellationToken.None);

            result.ShouldBeOfType<ProductEntity>();
            result.ShouldNotBeNull();
        }
    }
}
