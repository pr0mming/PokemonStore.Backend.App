using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonStore.Backend.Domain.DTOs.Order.Requests
{
    public class CreateProductRequestDTO
    {
        public string Name { get; set;}

        public string Description { get; set;}

        public long Price { get; set;}
    }
}
