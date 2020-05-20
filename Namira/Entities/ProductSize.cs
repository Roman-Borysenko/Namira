using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Entities
{
    public class ProductSize
    {
        public int Id { get; set; }
        [Required, Column("ProductId")]
        public Product Product { get; set; }
        [Required, Column("SizeId")]
        public Size Size { get; set; }
        [Required, MinLength(0)]
        public int Quantity { get; set; }
    }
}
