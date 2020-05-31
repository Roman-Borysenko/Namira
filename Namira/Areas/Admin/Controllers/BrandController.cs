using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
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