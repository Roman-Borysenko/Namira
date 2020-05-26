using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Namira.Areas.Admin.Models;
using Namira.Areas.Admin.ViewModels;
using Namira.Data;
using SlugGenerator;

namespace Namira.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private DataContext context;
        public CategoryController()
        {
            context = new DataContext();
        }
        public async Task<IActionResult> Index()
        {      
            return View(await context.Categories.ToListAsync());
        }
        public async Task<List<Entities.Language>> GetLanguages()
        {
            return await context.Languages.ToListAsync();
        }
        public async Task<List<Entities.Category>> GetCategories()
        {
            return await context.Categories.Include("Subcategories").Where(c => c.CategoryId == null).ToListAsync();
        }
        public async Task<CategoryViewModel> GetCvm()
        {
            var cvm = new CategoryViewModel();
            cvm.Categories = new List<Category>();
            cvm.Languages = await GetLanguages();
            cvm.ParentCategories = await GetCategories();

            return cvm;
        }
        public async Task<IActionResult> Add()
        {
            var cvm = await GetCvm();

            for (int i = 0; i < cvm.Languages.Count; i++)
                cvm.Categories.Add(new Category());

            return View(cvm);
        }
        [HttpPost]
        public async Task<IActionResult> Add(List<Category> categories)
        {
            if(!ModelState.IsValid)
            {
                var cvm = await GetCvm();
                cvm.Categories = categories;
                return View(cvm);
            }

            categories.ForEach(c => c.Slug = c.Name.GenerateSlug());

            var mapped = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Category, Entities.Category>()));
            var entities = mapped.Map<List<Entities.Category>>(categories);

            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();

            return RedirectToRoute("admin_area", new { controller = "Category", action = "Index" });
        }
    }
}