using Microsoft.AspNetCore.Mvc.Rendering;
using Namira.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Areas.Admin.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public List<ProductColor> ProductColors { get; set; }
        public List<ProductLanguage> ProductLanguages { get; set; }
        public List<Entities.Category> Categories { get; set; }
        public List<Entities.Language> Languages { get; set; }
        public SelectList Sizes { get; set; }
        public SelectList Brands { get; set; }
        public SelectList Countries { get; set; }
        public SelectList Fabrics { get; set; }
    }
}
