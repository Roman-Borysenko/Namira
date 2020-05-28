using System;

namespace Namira.Areas.Admin.Models
{
    public class Paginator
    {
        public int QuantityRecords { get; set; }
        public int QuantityPages => Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(QuantityRecords) / Convert.ToDecimal(SizePage)));
        public int SizePage { get; set; }
        public int Page { get; set; }
        public int Skipped => (Page * SizePage) - SizePage;
        public Link PaginatorRoute { get; set; }
    }
}
