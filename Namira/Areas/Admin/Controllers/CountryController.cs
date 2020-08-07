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
    public class CountryController : Controller
    {
        private DataContext context;
        public CountryController(DataContext dataContext)
        {
            context = dataContext;
        }
        public async Task<IActionResult> Index(int id = 1)
        {
            var paginator = new Paginator()
            {
                QuantityRecords = await context.Countries.CountAsync(),
                SizePage = 3,
                Page = id,
                PaginatorRoute = new Link() { Area = "Admin", Controller = "Country", Action = "Index" }
            };
            ViewBag.Paginator = paginator;
            return View(await context.Countries.OrderByDescending(c => c.Id).Skip(paginator.Skipped).Take(paginator.SizePage).ToListAsync());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Country country)
        {
            if (!ModelState.IsValid)
            {
                return View(country);
            }

            var mapped = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Country, Entities.Country>()));
            var entity = mapped.Map<Entities.Country>(country);

            entity.Slug = entity.Name.GenerateSlug();

            context.Countries.Add(entity);
            await context.SaveChangesAsync();

            return RedirectToRoute("admin_area", new { controller = "country", action = "index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            var mapped = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Entities.Country, Country>()));
            var country = mapped.Map<Country>(await context.Countries.SingleOrDefaultAsync(b => b.Id == id));

            ViewBag.Page = "edit";
            return View("Add", country);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Country country)
        {
            var entity = await context.Countries.SingleOrDefaultAsync(b => b.Id == country.Id);
            new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Country, Entities.Country>())).Map<Country, Entities.Country>(country, entity);
            entity.Slug = entity.Name.GenerateSlug();

            context.Countries.Update(entity);
            await context.SaveChangesAsync();

            return RedirectToRoute("admin_area", new { controller = "country", action = "index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            context.Countries.Remove(await context.Countries.SingleOrDefaultAsync(b => b.Id == id));
            await context.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}