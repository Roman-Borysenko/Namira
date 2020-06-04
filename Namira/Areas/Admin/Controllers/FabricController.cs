using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Namira.Areas.Admin.Models;
using Namira.Areas.Admin.ViewModels;
using Namira.Data;
using SlugGenerator;

namespace Namira.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FabricController : Controller
    {
        private DataContext context;
        public FabricController()
        {
            context = new DataContext();
        }
        public async Task<IActionResult> Index(int id = 1)
        {
            var paginator = new Paginator()
            {
                QuantityRecords = await context.Fabrics.CountAsync(),
                SizePage = 3,
                Page = id,
                PaginatorRoute = new Link() { Area = "Admin", Controller = "Fabric", Action = "Index" }
            };
            ViewBag.Paginator = paginator;
            return View(await context.Fabrics.OrderByDescending(c => c.Id).Skip(paginator.Skipped).Take(paginator.SizePage).ToListAsync());
        }
        public async Task<List<Entities.Language>> GetLanguages()
        {
            return await context.Languages.ToListAsync();
        }
        public async Task<CategoryViewModel<Fabric>> GetCvm()
        {
            var cvm = new CategoryViewModel<Fabric>();
            cvm.Data = new List<Fabric>();
            cvm.Languages = await GetLanguages();

            return cvm;
        }
        public async Task<IActionResult> Add()
        {
            var cvm = await GetCvm();

            for (int i = 0; i < cvm.Languages.Count; i++)
                cvm.Data.Add(new Fabric());

            return View(cvm);
        }
        [HttpPost]
        public async Task<IActionResult> Add(List<Fabric> data)
        {
            if (!ModelState.IsValid)
            {
                var cvm = await GetCvm();
                cvm.Data = data;
                return View(cvm);
            }

            var mapped = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Fabric, Entities.Fabric>()
                            .ForMember("Language", opt => opt.MapFrom(src => context.Languages
                                        .SingleOrDefault(l => l.Id == src.LanguageId)))));
            var entities = mapped.Map<List<Entities.Fabric>>(data);

            var guid = Guid.NewGuid().ToString();
            foreach (var item in entities)
            {
                item.Slug = item.Name.GenerateSlug();
                item.LanguageGroup = guid;
            }

            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();

            return RedirectToRoute("admin_area", new { controller = "Fabric", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            var entities = await context.Fabrics.Where(c => c.LanguageGroup == context.Fabrics.FirstOrDefault(c => c.Id == id).LanguageGroup).ToListAsync();

            var mapped = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Entities.Fabric, Fabric>()
                        .ForMember("LanguageId", opt => opt.MapFrom(src => src.Language.Id))));
            var fabrics = mapped.Map<List<Fabric>>(entities);

            var cvm = await GetCvm();
            cvm.Data.AddRange(fabrics);

            ViewBag.Page = "edit";
            return View("Add", cvm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(List<Fabric> data)
        {
            if (!ModelState.IsValid)
            {
                var cvm = await GetCvm();
                cvm.Data = data;
                return View(cvm);
            }

            var entities = new List<Entities.Fabric>();

            foreach (var item in data)
            {
                item.Slug = item.Name.GenerateSlug();
                var entity = context.Fabrics.FirstOrDefault(i => i.Id == item.Id);
                new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Fabric, Entities.Fabric>()
                    .ForMember("Language", opt => opt.MapFrom(src => context.Languages.SingleOrDefault(l => l.Id == src.LanguageId)))))
                    .Map<Fabric, Entities.Fabric>(item, entity);
                entities.Add(entity);
            }

            context.UpdateRange(entities);
            await context.SaveChangesAsync();

            return RedirectToRoute("admin_area", new { controller = "Fabric", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            context.Fabrics.RemoveRange(context.Fabrics.Where(c => c.LanguageGroup == context.Fabrics.SingleOrDefault(i => i.Id == id).LanguageGroup).ToList());
            await context.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}