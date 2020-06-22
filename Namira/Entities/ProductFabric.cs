using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Entities
{
    public class ProductFabric
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int FabricId { get; set; }
        public Fabric Fabric { get; set; }
    }
}
