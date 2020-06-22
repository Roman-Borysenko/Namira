using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Areas.Admin.Models
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
        [Range(0, 1000000)]
        public int View { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public List<int> FabricsId { get; set; }
        [Required]
        public string Foreground { get; set; }
        [Required]
        public string Background { get; set; }
        [Required]
        public int NumberPurchases { get; set; }
    }
}
