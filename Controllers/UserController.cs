using EcomerceProject.Entities;
using EcomerceProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceProject.Controllers
{
    public class UserController : Controller
    {
        private ApplicationContext context;
        public UserController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var u = context.User.Where(u => u.email.Equals(user.email) && u.password.Equals(user.password)).SingleOrDefault();
            if (u != null)
            {
                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(u));
                var shoppingCart = context.ShoppingCart.SingleOrDefault(s=>s.userid.Equals(u.id));
                if (shoppingCart != null)
                {
                    HttpContext.Session.SetString("cart", shoppingCart.content);
                }
                return RedirectToAction("UserIndex", controllerName: "Product");
            }
            else
            {
                ViewBag.Msg = "User or password wrong...";
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            HttpContext.Session.Remove("cart");
            return RedirectToAction("Login");
        }
    }
}
