using Microsoft.AspNetCore.Mvc;
using NetCuisine.DataBase;
using NetCuisine.Models;
using System.Linq;

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
        public IActionResult SignUp(SignUpModel signUpModel)
        {
            _signUpContext.Add(signUpModel);
            _signUpContext.SaveChanges();

            return Content("Data Added Successfully!");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            var signUpModel =  _signUpContext.signUp.FirstOrDefault(x => x.Email == Email && x.Password == Password);
            if (signUpModel == null)
            {
                return NotFound("Email or Password is Invalid!");
            }
            return Content("Login Successfull!");
        }
    }
}
