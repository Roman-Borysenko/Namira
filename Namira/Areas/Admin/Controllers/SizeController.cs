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
    public class SizeController : Controller
    {
        private DataContext context;
        public SizeController()
        {
            context = new DataContext();
        }
        public async Task<IActionResult> Index(int id = 1)
        {
            var paginator = new Paginator()
            {
                QuantityRecords = await context.Sizes.CountAsync(),
                SizePage = 3,
                Page = id,
                PaginatorRoute = new Link() { Area = "Admin", Controller = "Size", Action = "Index" }
            };
            ViewBag.Paginator = paginator;
            return View(await context.Sizes.OrderByDescending(c => c.Id).Skip(paginator.Skipped).Take(paginator.SizePage).ToListAsync());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Size size)
        {
            if (!ModelState.IsValid)
            {
                return View(size);
            }

            var mapped = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Size, Entities.Size>()));
            var entity = mapped.Map<Entities.Size>(size);

            entity.Slug = entity.Name.GenerateSlug();

            context.Sizes.Add(entity);
            await context.SaveChangesAsync();

            return RedirectToRoute("admin_area", new { controller = "size", action = "index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            var mapped = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Entities.Size, Size>()));
            var currency = mapped.Map<Size>(await context.Sizes.SingleOrDefaultAsync(b => b.Id == id));

            ViewBag.Page = "edit";
            return View("Add", currency);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Size size)
        {
            var entity = await context.Sizes.SingleOrDefaultAsync(b => b.Id == size.Id);
            new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Size, Entities.Size>())).Map<Size, Entities.Size>(size, entity);
            entity.Slug = entity.Name.GenerateSlug();

            context.Sizes.Update(entity);
            await context.SaveChangesAsync();

            return RedirectToRoute("admin_area", new { controller = "size", action = "index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            context.Sizes.Remove(await context.Sizes.SingleOrDefaultAsync(b => b.Id == id));
            await context.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}