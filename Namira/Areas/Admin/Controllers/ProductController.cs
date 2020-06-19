﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Namira.Areas.Admin.ViewModels;
using Namira.Areas.Admin.Models;
using Namira.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Namira.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private DataContext context;
        public ProductController()
        {
            context = new DataContext();
        }
        public IActionResult Index()
        {
            return View();
        }
        private async Task<ProductViewModel> GetProductViewModel()
        {
            var products = new List<ProductLanguage>();
            for (int i = 0; i < await context.Languages.CountAsync(); i++)
                products.Add(new ProductLanguage());

            var productViewModel = new ProductViewModel()
            {
                ProductLanguages = products,
                Categories = await context.Categories.Where(c => c.LanguageId == 1).ToListAsync(),
                Languages = await context.Languages.ToListAsync(),
                Brands = new SelectList(await context.Brands.ToListAsync(), "Id", "Name"),
                Countries = new SelectList(await context.Countries.ToListAsync(), "Id", "Name"),
                Fabrics = new SelectList(await context.Fabrics.ToListAsync(), "Id", "Name"),
                Sizes = new SelectList(await context.Sizes.ToListAsync(), "Id", "Name")
            };

            return productViewModel;
        }
        public async Task<IActionResult> Add()
        {
            return View(await GetProductViewModel());
        }
        [HttpPost]
        public string Add(Product product, List<ProductLanguage> productLanguages, List<ProductColor> productColors)
        {
            return $"{product.Price} - {productLanguages[0].Name} - {productColors[0].Color}";
        }
    }
}