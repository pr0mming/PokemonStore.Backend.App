using System.ComponentModel.DataAnnotations;

namespace PokemonStore.Backend.Domain.Entities
{
    public class ProductOrderItem
    {
        [Key]
        public string Id { get; set; }

        public int Ammount { get; set; }

        public ProductEntity Product { get; set; }

        public ProductOrderItem()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
