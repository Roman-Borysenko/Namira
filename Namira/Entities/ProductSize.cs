using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Namira.Entities
{
    public class ProductSize
    {
        public int Id { get; set; }
        [Required, Column("SizeId")]
        public Size Size { get; set; }
        [Required, Range(0, 1000000)]
        public int Quantity { get; set; }
        [Required]
        public ProductColor ProductColor { get; set; }
    }
}
