using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required, StringLength(60, MinimumLength = 1)]
        public string Slug { get; set; }
        [Required, StringLength(3)]
        public string Reduction { get; set; }
    }
}
