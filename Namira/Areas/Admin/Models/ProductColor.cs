using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Areas.Admin.Models
{
    public class ProductColor
    {
        public string Color { get; set; }
        public List<ColorSize> ColorSizes { get; set; }
        public List<string> Images { get; set; }
    }

    public class ColorSize
    { 
        public int SizeId { get; set; }
        public int Quantity { get; set; }
    }
}
