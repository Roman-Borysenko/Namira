using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required, Range(1000, 99999)]
        public int ProductCode { get; set; }
        [Required, Range(10, 1000000)]
        public decimal Price { get; set; }
        [Required, Range(1, 100)]
        public int Discount { get; set; }
        [Required, Range(1, 5)]
        public int Raiting { get; set; }
        [MinLength(0)]
        public int View { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public Country Country { get; set; }
        [Required]
        public Brand Brand { get; set; }
        [Required]
        public List<Fabric> Fabrics { get; set; }
        [Required]
        public List<ProductLanguage> ProductLanguages { get; set; }
        [Required]
        public List<ProductColor> ProductColors { get; set; }
        [Required]
        public string Foreground { get; set; }
        [Required]
        public string Background { get; set; }
        [Required]
        public List<NumberPurchase> NumberPurchases { get; set; }
        [Required]
        public DateTime Create { get; set; }
        [Required]
        public DateTime Update { get; set; }
    }
}