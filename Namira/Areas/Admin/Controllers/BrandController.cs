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
        public async Task<IActionResult> Edit(int id)
        {
            var mapped = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Entities.Brand, Brand>()));
            var brand = mapped.Map<Brand>(await context.Brands.SingleOrDefaultAsync(b => b.Id == id));

            ViewBag.Page = "edit";
            return View("Add", brand);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Brand brand)
        {
            var entity = await context.Brands.SingleOrDefaultAsync(b => b.Id == brand.Id);
            new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Brand, Entities.Brand>())).Map<Brand, Entities.Brand>(brand, entity);
            entity.Slug = entity.Name.GenerateSlug();

            context.Brands.Update(entity);
            await context.SaveChangesAsync();

            return RedirectToRoute("admin_area", new { controller = "brand", action = "index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            context.Brands.Remove(await context.Brands.SingleOrDefaultAsync(b => b.Id == id));
            await context.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}