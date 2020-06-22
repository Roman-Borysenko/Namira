using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Namira.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [Required]
        public ProductColor ProductColor { get; set; }
    }
}
