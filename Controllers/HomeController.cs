using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCuisine.Data;
using NetCuisine.Models;
using NetCuisine.Utilities;
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

            //var productCategoryId = (from ProductCategory in _context.ProductCategory
            //                         where ProductCategory.Id == int.ID
            //                         select ProductCategory.ProductCategoryId).SingleOrDefault();

           // IQueryable<ProductModel> source = _context.Product;
           // List<int> ss = new List<int>();

           // foreach (ProductModel item in source)
           // {
           //     ss.Add(item.ProductCategoryID);
           //     //Console.WriteLine("{0}: {1}", item.ProductName, item.UnitPrice);
           // }

           //var n = source.Count(x => x.ProductCategoryID == 7);
            //var i = ss.Count(x => x == 7);
            ////ss.Find(x => x.GetId() == "xy");
            //productViewModel.ProductsCount = (List<ProductCount>)(from p in _context.Product
            //                                                      group p by p.ProductCategoryID into g
            //                                                      select new
            //                                                      {
            //                                                          Name = g.Key,
            //                                                          Count = g.Count()
            //                                                      });

            //var NoOfProducts = from p in _context.Product
            //                   group p by p.ProductCategoryID into g
            //                   select new
            //                   {
            //                       Name = g.Key,
            //                       Count = g.Count()
            //                   };

            //productViewModel.ProductsCount = new SelectList(NoOfProducts, "Name", "Count").ToList();

            //ViewData["NoOfProducts"] = new SelectList(NoOfProducts, "Name", "Count");
            //var total = _context.ProductCategory.Count(x => x.Id != null);
            //productViewModel.Products = await _context.Product.ToListAsync();

            productViewModel.Products = _context.Product.OrderByDescending(x => x.Id).ToList();

            return View(productViewModel);
        }


        public async Task<IActionResult> ProductList(string sortOrder, string searchString, string currentFilter, int? pageNumber, int? pageSize)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var AllProducts = from s in _context.Product
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                AllProducts = AllProducts.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
                //|| s.Email.ToUpper().Contains(searchString.ToUpper())
                /*|| s.Orderstatus.ToUpper().Contains(searchString.ToUpper())*/
            }


            switch (sortOrder)
            {
                case "name_desc":
                    AllProducts = AllProducts.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    AllProducts = AllProducts.OrderBy(s => s.Price);
                    break;
                case "date_desc":
                    AllProducts = AllProducts.OrderByDescending(s => s.ProductCategory);
                    break;
                default:
                    AllProducts = AllProducts.OrderBy(s => s.Id);
                    break;
            }

            if (pageSize == null)
            {
                pageSize = 10;
            }

            return View(await PaginatedList<ProductModel>.CreateAsync(AllProducts.AsNoTracking(), pageNumber ?? 1, (int)pageSize));

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

        public IActionResult AboutUS()
        {
            return View();
        }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
