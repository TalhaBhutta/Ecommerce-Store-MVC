using Microsoft.AspNetCore.Mvc;
using NetCuisine.Models;

namespace NetCuisine.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSignUp(SignUpModel signUpModel)
        {
            return View();
        }
    }
}
