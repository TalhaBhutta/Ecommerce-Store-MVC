using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index(int? Id)
        {
            if(Id > 0)
            {
                return Content("Id: "+Id);
            }
            return View();
        }

        public IActionResult userLogin()
        {
          
            return View();
        }

        [HttpPost]
        public IActionResult userLogin(LoginModel login)
        {

            if(login.UserName == "Farhan" && login.password == "Gay")
            {
                return Content("Login Successfull!");
            }
            else
            {
                return Content("Invalid Login or password");
            }
           
            
        }
    }
}
