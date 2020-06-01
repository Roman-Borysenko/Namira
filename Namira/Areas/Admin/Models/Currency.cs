using System.ComponentModel.DataAnnotations;

namespace Namira.Areas.Admin.Models
{
    public class Currency
    {
        public int? Id { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [StringLength(60, MinimumLength = 1)]
        public string Slug { get; set; }
        [Required, StringLength(3)]
        public string Reduction { get; set; }
    }
}
