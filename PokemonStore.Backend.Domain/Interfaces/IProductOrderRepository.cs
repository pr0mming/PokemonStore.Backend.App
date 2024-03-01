using PokemonStore.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonStore.Backend.Domain.Interfaces
{
    public interface IProductOrderRepository
    {
        Task<List<OrderEntity>> GetOrdersListAsync();

        Task<OrderEntity> CreateOrderAsync(OrderEntity order);
    }
}
