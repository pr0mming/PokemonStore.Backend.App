using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonStore.Backend.Domain.Entities
{
    public class ProductEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public long Price { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreationDate { get; set; }

        public ProductEntity()
        {
            CreationDate = DateTime.Now;
        }
    }
}
