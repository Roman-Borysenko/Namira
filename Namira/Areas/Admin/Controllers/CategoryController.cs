using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
        public async Task<IActionResult> Index(int id = 1)
        {
            var paginator = new Paginator() { QuantityRecords = await context.Categories.CountAsync(), SizePage = 3, Page = id, 
                PaginatorRoute = new Link() { Area = "Admin", Controller = "Category", Action = "Index" } };
            ViewBag.Paginator = paginator;
            return View(await context.Categories.OrderByDescending(c => c.Id).Skip(paginator.Skipped).Take(paginator.SizePage).ToListAsync());
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

            var mapped = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Category, Entities.Category>()));
            var entities = mapped.Map<List<Entities.Category>>(categories);

            var guid = Guid.NewGuid().ToString();
            foreach (var item in entities)
            {
                item.Slug = item.Name.GenerateSlug();
                item.LanguageGroup = guid;
            }

            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();

            return RedirectToRoute("admin_area", new { controller = "Category", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            var entities = await context.Categories.Where(c => c.LanguageGroup == context.Categories.FirstOrDefault(c => c.Id == id).LanguageGroup).ToListAsync();

            var mapped = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Entities.Category, Category>()));
            var categories = mapped.Map<List<Category>>(entities);

            var cvm = await GetCvm();
            cvm.Categories.AddRange(categories);

            ViewBag.Page = "edit";
            return View("Add", cvm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(List<Category> categories)
        {
            if (!ModelState.IsValid)
            {
                var cvm = await GetCvm();
                cvm.Categories = categories;
                return View(cvm);
            }

            var entities = new List<Entities.Category>();

            foreach (var item in categories)
            {
                item.Slug = item.Name.GenerateSlug();
                var entity = context.Categories.FirstOrDefault(i => i.Id == item.Id);
                new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Category, Entities.Category>())).Map<Category, Entities.Category>(item, entity);
                entities.Add(entity);
            }

            context.UpdateRange(entities);
            await context.SaveChangesAsync();

            return RedirectToRoute("admin_area", new { controller = "Category", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id) 
        {
            context.Categories.RemoveRange(context.Categories.Include("Subcategories").Where(c => c.LanguageGroup == context.Categories.SingleOrDefault(i => i.Id == id).LanguageGroup).ToList());
            await context.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}