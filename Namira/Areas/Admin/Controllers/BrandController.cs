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
    public class BrandController : Controller
    {
        private DataContext context;
        public BrandController()
        {
            context = new DataContext();
        }
        public async Task<IActionResult> Index(int id = 1)
        {
            var paginator = new Paginator()
            {
                QuantityRecords = await context.Brands.CountAsync(),
                SizePage = 3,
                Page = id,
                PaginatorRoute = new Link() { Area = "Admin", Controller = "Brand", Action = "Index" }
            };
            ViewBag.Paginator = paginator;
            return View(await context.Brands.OrderByDescending(c => c.Id).Skip(paginator.Skipped).Take(paginator.SizePage).ToListAsync());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Brand brand)
        {
            if(!ModelState.IsValid)
            {
                return View(brand);
            }

            var mapped = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Brand, Entities.Brand>()));
            var entity = mapped.Map<Entities.Brand>(brand);

            entity.Slug = entity.Name.GenerateSlug();

            context.Brands.Add(entity);
            await context.SaveChangesAsync();

            return RedirectToRoute("admin_area", new { controller = "brand", action = "index" });
        }
    }
}