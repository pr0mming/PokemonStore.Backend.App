using Microsoft.EntityFrameworkCore;
using PokemonStore.Backend.Domain.Entities;
using PokemonStore.Backend.Domain.Interfaces;
using PokemonStore.Backend.Infrastructure.Persistence;

namespace PokemonStore.Backend.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductEntity?> GetProductByIdAsync(string id)
        {
            
            return await _context
                .Products
                .FindAsync(id);

        }

        public async Task<List<ProductEntity>> GetProductsListAsync()
        {

            return await _context.Products
                .Where(item => item.IsActive)
                .ToListAsync();

        }

        public async Task<ProductEntity> CreateProductAsync(ProductEntity product)
        {
            
            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product;

        }

        public async Task<ProductEntity> UpdateProductAsync(ProductEntity product)
        {

            var result = _context.Products.Update(product);

            await _context.SaveChangesAsync();

            return result.Entity;

        }

    }
}
