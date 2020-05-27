using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Areas.Admin.Models
{
    public class Paginator
    {
        public int QuantityRecords { get; set; }
        public int QuantityPages => Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(QuantityRecords) / Convert.ToDecimal(SizePage)));
        public int SizePage { get; set; }
        public int Page { get; set; }
        public int Skipped => (Page * SizePage) - SizePage;
        public PaginatorRoute PaginatorRoute { get; set; }
    }

    public class PaginatorRoute
    {
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Dictionary<string, string> Params { get; set; }
    }
}
