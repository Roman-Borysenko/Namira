using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Namira.Entities
{
    public class Fabric
    {
        public int Id { get; set; }
        [Required, StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }
        [Required, StringLength(140, MinimumLength = 1)]
        public string Slug { get; set; }
        [Required]
        public List<ProductFabric> ProductFabrics { get; set; }
        [Required]
        public Language Language { get; set; }
        [Required]
        public string LanguageGroup { get; set; }
    }
}
