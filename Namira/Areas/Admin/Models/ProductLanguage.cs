﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Areas.Admin.Models
{
    public class ProductLanguage
    {
        public int Id { get; set; }
        [Required, StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }
        [StringLength(130, MinimumLength = 1)]
        public string Slug { get; set; }
        [Required, StringLength(10000, MinimumLength = 100)]
        public string Description { get; set; }
        [Required, StringLength(1000, MinimumLength = 100)]
        public string MetaDescription { get; set; }
        [Required, StringLength(1000, MinimumLength = 50)]
        public string MetaKeywords { get; set; }
        [Required]
        public int LanguageId { get; set; }
    }
}
