using System.Collections.Generic;

namespace Namira.Areas.Admin.Models
{
    public class Link
    {
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Dictionary<string, string> Params { get; set; }
    }
}
