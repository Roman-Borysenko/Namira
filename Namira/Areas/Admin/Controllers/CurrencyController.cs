using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Namira.Areas.Admin.Models;
using Namira.Data;
using SlugGenerator;
using System.Linq;
using System.Threading.Tasks;

namespace Namira.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CurrencyController : Controller
    {
        private DataContext context;
        public CurrencyController()
        {
            context = new DataContext();
        }
        public async Task<IActionResult> Index(int id = 1)
        {
            var paginator = new Paginator()
            {
                QuantityRecords = await context.Currencies.CountAsync(),
                SizePage = 3,
                Page = id,
                PaginatorRoute = new Link() { Area = "Admin", Controller = "Currency", Action = "Index" }
            };
            ViewBag.Paginator = paginator;
            return View(await context.Currencies.OrderByDescending(c => c.Id).Skip(paginator.Skipped).Take(paginator.SizePage).ToListAsync());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return View(currency);
            }

            var mapped = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Currency, Entities.Currency>()));
            var entity = mapped.Map<Entities.Currency>(currency);

            entity.Slug = entity.Name.GenerateSlug();

            context.Currencies.Add(entity);
            await context.SaveChangesAsync();

            return RedirectToRoute("admin_area", new { controller = "currency", action = "index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            var mapped = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Entities.Currency, Currency>()));
            var currency = mapped.Map<Currency>(await context.Currencies.SingleOrDefaultAsync(b => b.Id == id));

            ViewBag.Page = "edit";
            return View("Add", currency);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Currency currency)
        {
            var entity = await context.Currencies.SingleOrDefaultAsync(b => b.Id == currency.Id);
            new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Currency, Entities.Currency>())).Map<Currency, Entities.Currency>(currency, entity);
            entity.Slug = entity.Name.GenerateSlug();

            context.Currencies.Update(entity);
            await context.SaveChangesAsync();

            return RedirectToRoute("admin_area", new { controller = "currency", action = "index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            context.Currencies.Remove(await context.Currencies.SingleOrDefaultAsync(b => b.Id == id));
            await context.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}