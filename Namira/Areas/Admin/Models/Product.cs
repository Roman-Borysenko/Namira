using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Namira.Areas.Admin.Models
{
    public class Product
    {
        public int? Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required, StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }
        [StringLength(130, MinimumLength = 1)]
        public string Slug { get; set; }
        [Required]
        public int LanguageId { get; set; }
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
        public List<int> FabricsId { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required, StringLength(10000, MinimumLength = 100)]
        public string Description { get; set; }
        [Required, StringLength(1000, MinimumLength = 100)]
        public string MetaDescription { get; set; }
        [Required, StringLength(1000, MinimumLength = 50)]
        public string MetaKeywords { get; set; }
        [Required]
        public List<int> ProductSizesId { get; set; }
        [Required]
        public List<int> ProductColorsId { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required, StringLength(200, MinimumLength = 10)]
        public string Foreground { get; set; }
        [Required, StringLength(200, MinimumLength = 10)]
        public string Background { get; set; }
        [Required]
        public int NumberPurchases { get; set; }
    }
}
