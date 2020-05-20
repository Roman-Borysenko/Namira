using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }
        [Required, Column("ColorId")]
        public ProductColor ProductColors { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}
