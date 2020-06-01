using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Areas.Admin.Models
{
    public class Language
    {
        public int? Id { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [StringLength(60, MinimumLength = 2)]
        public string Slug { get; set; }
        [Required, StringLength(2)]
        public string Reduction { get; set; }
    }
}
