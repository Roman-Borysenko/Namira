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
        [Column("ParentId")]
        public List<Category> Subcategories { get; set; }
        public Language Language { get; set; }
    }
}
