using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonStore.Backend.Domain.Entities
{
    public class OrderEntity
    {
        [Key]
        public string Id { get; set; }

        public IList<ProductOrderItem> OrderItems { get; set; } = new List<ProductOrderItem>();

        public DateTime CreationDate { get; set; }

        public OrderEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreationDate = DateTime.Now;
        }

    }
}
