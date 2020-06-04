using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Areas.Admin.Models
{
    public class Fabric
    {
        public int? Id { get; set; }
        [Required, StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }
        [StringLength(140, MinimumLength = 1)]
        public string Slug { get; set; }
        [Required]
        public int LanguageId { get; set; }
    }
}
