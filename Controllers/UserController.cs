using Microsoft.AspNetCore.Mvc;
using NetCuisine.DataBase;
using NetCuisine.Models;

namespace NetCuisine.Controllers
{
    [Route("{controller}/{action}")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _signUpContext;

        public UserController(ApplicationDbContext context)
        {
            _signUpContext = context;
        }
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
            _signUpContext.Add(signUpModel);
            _signUpContext.SaveChanges();

            return Content("Data Added Successfully!");
        }
    }
}
