using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCuisine.Data;
using NetCuisine.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly NetCuisineContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;


        public HomeController(ILogger<HomeController> logger, NetCuisineContext context, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task <IActionResult> Index()
        {
            ProductViewModel productViewModel = new ProductViewModel();

            productViewModel.Categories = await _context.ProductCategory.ToListAsync();
            productViewModel.Products = await _context.Product.ToListAsync();

            return View(productViewModel);
        }

        public async Task<IActionResult> ProductList()
        {
            var AllProducts = await _context.Product.Include(p => p.ProductCategory).ToListAsync();
            ViewBag.products = AllProducts;
            return View(AllProducts);
        }
        public async Task<IActionResult> ProductDetails(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.Product
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productModel == null)
            {
                return NotFound();
            }
            ProductsListDetailViewModel productsListDetailViewModel = new ProductsListDetailViewModel();
            productsListDetailViewModel.Id = productModel.Id;
            productsListDetailViewModel.Description = productModel.Description;
            productsListDetailViewModel.Picture = productModel.Picture;
            productsListDetailViewModel.Name = productModel.Name;
            productsListDetailViewModel.Price = productModel.Price;
            productsListDetailViewModel.ProductCategoryID = productModel.ProductCategoryID;
            productsListDetailViewModel.Quantity = 1;

            var AllProducts = await _context.Product.Include(p => p.ProductCategory).ToListAsync();
            productsListDetailViewModel.Products = AllProducts;

            return View(productsListDetailViewModel);
        }
        public async Task<IActionResult> ProductDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.Product
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
