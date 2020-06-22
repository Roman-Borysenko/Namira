using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Namira.Entities
{
    public class ProductColor
    {
        public int Id { get; set; }
        [Required, Column("ProductId")]
        public Product Product { get; set; }
        [Required, StringLength(7)]
        public string Color { get; set; }
        [Required]
        public List<ProductSize> ProductSizes { get; set; }
        [Required]
        public List<ProductImage> ProductImages { get; set; }
    }
}
