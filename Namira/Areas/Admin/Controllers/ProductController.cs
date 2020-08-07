using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Namira.Areas.Admin.ViewModels;
using Namira.Areas.Admin.Models;
using Namira.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
using SlugGenerator;

namespace Namira.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private DataContext context;
        public ProductController(DataContext dataContext)
        {
            context = dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        private async Task<ProductViewModel> GetProductViewModel()
        {
            var products = new List<ProductLanguage>();
            for (int i = 0; i < await context.Languages.CountAsync(); i++)
                products.Add(new ProductLanguage());

            var productViewModel = new ProductViewModel()
            {
                Product = new Product(),
                ProductLanguages = products,
                Categories = await context.Categories.Where(c => c.LanguageId == 1).ToListAsync(),
                Languages = await context.Languages.ToListAsync(),
                Brands = new SelectList(await context.Brands.ToListAsync(), "Id", "Name"),
                Countries = new SelectList(await context.Countries.ToListAsync(), "Id", "Name"),
                Fabrics = new SelectList(await context.Fabrics.ToListAsync(), "Id", "Name"),
                Sizes = new SelectList(await context.Sizes.ToListAsync(), "Id", "Name")
            };

            return productViewModel;
        }
        public async Task<IActionResult> Add()
        {
            return View(await GetProductViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Add(Product product, List<ProductLanguage> productLanguages, List<ProductColor> productColors)
        {
            if(!ModelState.IsValid)
            {
                var productViewModel = await GetProductViewModel();
                productViewModel.Product = product;
                productViewModel.ProductLanguages = productLanguages;
                productViewModel.ProductColors = productColors;

                return View(productViewModel);
            }
            var mappedProductSize = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ColorSize, Entities.ProductSize>()
                .ForMember("Size", opt => opt.MapFrom(src => context.Sizes.SingleOrDefault(s => s.Id == src.SizeId)))
            ));
            var mappedProductImage = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<string, Entities.ProductImage>()
                .ForMember("Image", opt => opt.MapFrom(src => Convert.FromBase64String(src.Split(new char[] { ',' })[1])))
            ));
            var mappedProductColors = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ProductColor, Entities.ProductColor>()
                .ForMember("ProductSizes", opt => opt.MapFrom(src => mappedProductSize.Map<List<Entities.ProductSize>>(src.ColorSizes)))
                .ForMember("ProductImages", opt => opt.MapFrom(src => mappedProductImage.Map<List<Entities.ProductImage>>(src.Images)))
            ));

            var mappedProductLanguages = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ProductLanguage, Entities.ProductLanguage>()
                .ForMember("Slug", opt => opt.MapFrom(src => src.Name.GenerateSlug("-")))
                .ForMember("Language", opt => opt.MapFrom(src => context.Languages.SingleOrDefault(l => l.Id == src.LanguageId)))
            ));

            var mappedProductFabric = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<int, Entities.ProductFabric>()
                .ForMember("Fabric", opt => opt.MapFrom(src => context.Fabrics.SingleOrDefault(f => f.Id == src)))
                .ForMember("FabricId", opt => opt.MapFrom(src => src))
            ));

            var mappedProducts = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Product, Entities.Product>()
                .ForMember("Foreground", opt => opt.MapFrom(src => Convert.FromBase64String(src.Foreground.Split(new char[] { ',' })[1])))
                .ForMember("Background", opt => opt.MapFrom(src => Convert.FromBase64String(src.Background.Split(new char[] { ',' })[1])))
                .ForMember("Category", opt => opt.MapFrom(src => context.Categories.SingleOrDefault(c => c.Id == src.CategoryId)))
                .ForMember("Country", opt => opt.MapFrom(src => context.Countries.SingleOrDefault(c => c.Id == src.CountryId)))
                .ForMember("Brand", opt => opt.MapFrom(src => context.Brands.SingleOrDefault(b => b.Id == src.BrandId)))
                .ForMember("ProductFabrics", opt => opt.MapFrom(src => mappedProductFabric.Map<List<Entities.ProductFabric>>(product.FabricsId)))
                .ForMember("ProductLanguages", opt => opt.MapFrom(src => mappedProductLanguages.Map<List<Entities.ProductLanguage>>(productLanguages)))
                .ForMember("ProductColors", opt => opt.MapFrom(src => mappedProductColors.Map<List<Entities.ProductColor>>(productColors)))
                .ForMember("NumberPurchases", opt => opt.MapFrom(src => new Entities.NumberPurchase().GetList(src.NumberPurchases)))
                .ForMember("Create", opt => opt.MapFrom(src => DateTime.Now))
                .ForMember("Update", opt => opt.MapFrom(src => DateTime.Now))
            ));
            var entitieProducts = mappedProducts.Map<Entities.Product>(product);

            await context.AddAsync(entitieProducts);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}