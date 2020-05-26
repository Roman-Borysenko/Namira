using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Areas.Admin.ViewModels
{
    public class DataOutputViewModel
    {
        public dynamic Data { get; set; }
        public Type DataType { get; set; }
        public string[] Fields { get; set; } 
    }
}
