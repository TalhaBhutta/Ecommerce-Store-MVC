using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCuisine.Areas.Identity.Data;
using NetCuisine.Data;
using NetCuisine.Helpers;
using NetCuisine.Models;
using NetCuisine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCuisine.Controllers
{
    [Authorize]
    [Route("cart")]
    public class CartController : Controller
    {
        private readonly NetCuisineContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<NetCuisineUser> _userManager;
        public CartController(NetCuisineContext context, IHttpContextAccessor httpContextAccessor, UserManager<NetCuisineUser> userManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        [Route("index")]
        public IActionResult IndexAsync()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            List<Item> FinalCart = new List<Item>();
            foreach (Item item in cart)
            {
                if (item.UserId == userId)
                {
                    FinalCart.Add(item);
                }
            }
            //for (int i = 0; i < cart.Count; i++)
            //{
            //    if (cart[i].UserId == userId)
            //    {
            //        FinalCart.Add(cart[i]);
            //    }
            //}
            ViewBag.cart = FinalCart;
            ViewBag.total = FinalCart.Sum(item => item.Product.Price * item.Quantity);

            return View();
        }

        [Route("buy/{id}")]
        public async Task<IActionResult> BuyAsync(int id)
        {
            var ID = Convert.ToInt32(id);

            ProductModel productModel = new ProductModel();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            //var userNames = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

            //var applicationUser = await _userManager.GetUserAsync(User);
            //string userEmail = applicationUser?.Email;
            //string value = userId + "_";
            //string key = "key";
            //CookieOptions option = new CookieOptions();
            //option.Expires = DateTime.Now.AddMinutes(1);

            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = _context.Product.Include(p => p.ProductCategory).FirstOrDefault(m => m.Id == ID), Quantity = 1, UserId = userId });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                //foreach (var i in cart)
                //{
                //    value += i.Product.Id +",";
                //    value += i.Product.Price + ",";
                //    value += i.Quantity + ",";

                //}
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = _context.Product.Include(p => p.ProductCategory).FirstOrDefault(m => m.Id == ID), Quantity = 1, UserId = userId });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                //foreach (var i in cart)
                //{
                //    value += i.Product.Id + ",";
                //    value += i.Product.Price + ",";
                //    value += i.Quantity + ",";
                //}
            }




            //Response.Cookies.Append(key, value, option);
            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if(userId == cart[i].UserId)
                {
                    if (cart[i].Product.Id == id)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}
