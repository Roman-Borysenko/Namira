using System.ComponentModel.DataAnnotations;

namespace Namira.Areas.Admin.Models
{
    public class Size
    {
        public int? Id { get; set; }
        [Required, StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }
        [StringLength(140, MinimumLength = 1)]
        public string Slug { get; set; }
        [Required, StringLength(4, MinimumLength = 1)]
        public string Reduction { get; set; }
    }
}
