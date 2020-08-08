using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Areas.Admin.Models
{
    public class ProductColor
    {
        [Required, StringLength(7)]
        public string Color { get; set; }
        [Required]
        public List<ColorSize> ColorSizes { get; set; }
        [Required]
        public List<string> Images { get; set; }
    }

    public class ColorSize
    { 
        [Required]
        public int SizeId { get; set; }
        [Required, Range(1, 1000000)]
        public int Quantity { get; set; }
    }
}
