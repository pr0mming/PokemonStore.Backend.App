using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonStore.Backend.Domain.DTOs.Order.Requests
{
    public class CreateOrderItemRequestDTO
    {
        public string ProductId { get; set; }

        public int Ammount { get; set; }
    }

    public class CreateOrderRequestDTO
    {
        public List<CreateOrderItemRequestDTO> Items { get; set; } = new List<CreateOrderItemRequestDTO>();
    }
}
