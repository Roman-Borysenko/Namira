using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required, StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }
        public string Slug { get; set; }
        [Required, StringLength(1000, MinimumLength = 100)]
        public string MetaDescription { get; set; }
        [Required, StringLength(1000, MinimumLength = 50)]
        public string MetaKeywords { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public List<Category> Subcategories { get; set; }
        [Required]
        public int LanguageId { get; set; }
        [NotMapped, ForeignKey("LanguageId")]
        public Language Language { get; set; } 
    }
}
