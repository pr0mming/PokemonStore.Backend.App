using PokemonStore.Backend.Application.Products.Queries.GetProducts;
using PokemonStore.Backend.Domain.Entities;
using PokemonStore.Backend.Domain.Interfaces;
using PokemonStore.Backend.UnitTests.Mocks;
using Shouldly;
using Xunit;

namespace PokemonStore.Backend.UnitTests.Tests.Queries
{
    public class GetProductsListQueryTest
    {
        private readonly IProductRepository _mockProductRepository;

        public GetProductsListQueryTest()
        {
            _mockProductRepository = MockProductRepository.GetProductRepository().Object;
        }

        [Fact]
        public async Task GetProductsList()
        {
            var handler = new GetProductsListQueryHandler(_mockProductRepository);
            var result = await handler.Handle(new GetProductsListQuery(), CancellationToken.None);

            Console.WriteLine(result[0].Id);

            result.ShouldBeOfType<List<ProductEntity>>();
            result.Count.ShouldBeGreaterThan(0);
        }
    }
}
