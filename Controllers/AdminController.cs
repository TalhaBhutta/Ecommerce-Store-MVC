using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCuisine.Data;
using NetCuisine.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCuisine.Controllers
{
    public class AdminController : Controller
    {
       

        private readonly NetCuisineContext _context;

        public AdminController(NetCuisineContext context)
        {
            _context = context;
        }
        public IActionResult AdminDashboard()
        {
            return View();
        }


        public async Task<IActionResult> AdminDashboard2Async()
        {
            ProductViewModel productViewModel = new ProductViewModel();

            productViewModel.Categories = await _context.ProductCategory.ToListAsync();
            productViewModel.Products = await _context.Product.ToListAsync();
            
            return View(productViewModel);
        }
    }
}
