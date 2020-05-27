using System.ComponentModel.DataAnnotations;

namespace Namira.Areas.Admin.Models
{
    public class Category
    {
        public int? Id { get; set; }
        [Required, StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }
        [StringLength(140, MinimumLength = 1)]
        public string Slug { get; set; }
        [Required, StringLength(1000, MinimumLength = 100), Display(Name = "Meta description")]
        public string MetaDescription { get; set; }
        [Required, StringLength(1000, MinimumLength = 50), Display(Name = "Meta keywords")]
        public string MetaKeywords { get; set; }
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        [Required]
        public int LanguageId { get; set; }
    }
}
