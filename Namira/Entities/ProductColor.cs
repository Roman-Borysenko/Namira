using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Entities
{
    public class ProductColor
    {
        public int Id { get; set; }
        [Required, Column("ProductId")]
        public Product Product { get; set; }
        [Required, StringLength(30, MinimumLength = 2)]
        public string NameColor { get; set; }
        [Required, StringLength(7)]
        public string Colors { get; set; }
        [Required]
        public List<ProductImage> ProductImages { get; set; }
    }
}
