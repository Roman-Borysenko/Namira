﻿using System.ComponentModel.DataAnnotations;

namespace Namira.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public ProductColor ProductColor { get; set; }
    }
}
