using MediatR;
using PokemonStore.Backend.Domain.Entities;
using PokemonStore.Backend.Domain.Interfaces;

namespace PokemonStore.Backend.Application.Products.Queries.GetProducts
{
    public record GetProductsListQuery : IRequest<List<ProductEntity>>;

    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, List<ProductEntity>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsListQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<List<ProductEntity>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            return _productRepository.GetProductsListAsync();
        }
    }
}
