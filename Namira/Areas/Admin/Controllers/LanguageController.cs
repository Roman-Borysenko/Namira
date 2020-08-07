using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Namira.Areas.Admin.Models;
using Namira.Data;
using SlugGenerator;

namespace Namira.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LanguageController : Controller
    {
        private DataContext context;
        public LanguageController(DataContext dataContext)
        {
            context = dataContext;
        }
        public async Task<IActionResult> Index(int id = 1)
        {
            var paginator = new Paginator()
            {
                QuantityRecords = await context.Languages.CountAsync(),
                SizePage = 3,
                Page = id,
                PaginatorRoute = new Link() { Area = "Admin", Controller = "Language", Action = "Index" }
            };
            ViewBag.Paginator = paginator;
            return View(await context.Languages.OrderByDescending(c => c.Id).Skip(paginator.Skipped).Take(paginator.SizePage).ToListAsync());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Language language)
        {
            if (!ModelState.IsValid)
            {
                return View(language);
            }

            var mapped = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Language, Entities.Language>()));
            var entity = mapped.Map<Entities.Language>(language);

            entity.Slug = entity.Name.GenerateSlug();

            context.Languages.Add(entity);
            await context.SaveChangesAsync();

            return RedirectToRoute("admin_area", new { controller = "language", action = "index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            var mapped = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Entities.Language, Language>()));
            var brand = mapped.Map<Language>(await context.Languages.SingleOrDefaultAsync(b => b.Id == id));

            ViewBag.Page = "edit";
            return View("Add", brand);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Language language)
        {
            var entity = await context.Languages.SingleOrDefaultAsync(b => b.Id == language.Id);
            new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Language, Entities.Language>())).Map<Language, Entities.Language>(language, entity);
            entity.Slug = entity.Name.GenerateSlug();

            context.Languages.Update(entity);
            await context.SaveChangesAsync();

            return RedirectToRoute("admin_area", new { controller = "language", action = "index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            context.Languages.Remove(await context.Languages.SingleOrDefaultAsync(b => b.Id == id));
            await context.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}