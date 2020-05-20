using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Entities
{
    public class NumberPurchase
    {
        public int Id { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
