using System.ComponentModel.DataAnnotations;

namespace Namira.Areas.Admin.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }
        [Required, StringLength(140, MinimumLength = 1)]
        public string Slug { get; set; }
        [Required, StringLength(1000, MinimumLength = 100)]
        public string MetaDescription { get; set; }
        [Required, StringLength(1000, MinimumLength = 50)]
        public string MetaKeywords { get; set; }
        public int Language { get; set; }
    }
}
