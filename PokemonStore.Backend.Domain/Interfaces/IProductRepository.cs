using PokemonStore.Backend.Domain.Entities;

namespace PokemonStore.Backend.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductEntity?> GetProductByIdAsync(string id);

        Task<List<ProductEntity>> GetProductsListAsync();

        Task<ProductEntity> CreateProductAsync(ProductEntity product);

        Task<ProductEntity> UpdateProductAsync(ProductEntity product);
    }
}
