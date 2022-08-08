using Microsoft.AspNetCore.Mvc;

namespace NetCuisine.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}
