using Microsoft.EntityFrameworkCore;
using PokemonStore.Backend.Domain.Entities;
using PokemonStore.Backend.Domain.Interfaces;
using PokemonStore.Backend.Infrastructure.Persistence;

namespace PokemonStore.Backend.Infrastructure.Repositories
{
    public class ProductOrderRepository : IProductOrderRepository
    {

        private readonly ApplicationDbContext _context;

        public ProductOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<OrderEntity>> GetOrdersListAsync()
        {
            return _context.Orders
                .Include(order => order.OrderItems)
                .ThenInclude(item => item.Product)
                .ToListAsync();
        }

        public async Task<OrderEntity> CreateOrderAsync(OrderEntity order)
        {

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return order;

        }

    }
}
