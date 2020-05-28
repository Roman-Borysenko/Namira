using Namira.Areas.Admin.Models;
using System;

namespace Namira.Areas.Admin.ViewModels
{
    public class DataOutputViewModel
    {
        public dynamic Data { get; set; }
        public Type DataType { get; set; }
        public string[] Fields { get; set; } 
        public Link EditLink { get; set; }
    }
}
