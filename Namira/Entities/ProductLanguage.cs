using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Entities
{
    public class ProductLanguage
    {
        public int Id { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required, StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }
        [Required, StringLength(130, MinimumLength = 1)]
        public string Slug { get; set; }
        [Required, StringLength(10000, MinimumLength = 100)]
        public string Description { get; set; }
        [Required, StringLength(1000, MinimumLength = 100)]
        public string MetaDescription { get; set; }
        [Required, StringLength(1000, MinimumLength = 50)]
        public string MetaKeywords { get; set; }
        [Required]
        public Language Language { get; set; }
    }
}
