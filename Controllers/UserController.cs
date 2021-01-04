using EcomerceProject.Entities;
using EcomerceProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomerceProject.Helpers;

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
            var u = context.User.Where(u => u.email.Equals(user.email) && u.password.Equals(Encryptor.MD5Hash(user.password))).SingleOrDefault();
            if (u != null)
            {
                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(u));
                var shoppingCart = context.ShoppingCart.SingleOrDefault(s=>s.userid.Equals(u.id));
                var cart = HttpContext.Session.GetString("cart");
                if (shoppingCart != null)
                {
                    HttpContext.Session.SetString("cart", shoppingCart.content);
                    if (cart != null)
                    {
                        var dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                        var dataSCart = JsonConvert.DeserializeObject<List<Cart>>(shoppingCart.content);
                        for (int i = 0; i < dataCart.Count; i++)
                        {
                            int count = 0;
                            for (int j = 0; j < dataSCart.Count; j++)
                            {

                                if (dataCart[i].product.id.Equals(dataSCart[j].product.id))
                                {
                                    dataSCart[j].quantity += dataCart[i].quantity;
                                    count++;
                                }
                            }
                            if (count == 0)
                            {
                                dataSCart.Add(dataCart[i]);
                            }
                        }
                        shoppingCart.content = JsonConvert.SerializeObject(dataSCart);
                        context.SaveChanges();
                        HttpContext.Session.SetString("cart", shoppingCart.content);
                    }
                }
                else if (shoppingCart == null)
                {
                    if (cart != null)
                    {
                        ShoppingCart sCart = new ShoppingCart()
                        {
                            userid = u.id,
                            content = cart
                        };
                        context.ShoppingCart.Add(sCart);
                        context.SaveChanges();
                    }
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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            try
            {
                var model = context.User.FirstOrDefault(m => m.email.Equals(user.email));
                if (model == null)
                {
                    if (ModelState.IsValid)
                    {
                        user.password = Encryptor.MD5Hash(user.password);
                        context.User.Add(user);
                        context.SaveChanges();
                        return RedirectToAction("Login", controllerName: "User");
                    }
                }
                else
                {
                    ViewBag.Msg = "Email is existing...";
                }
            }
            catch (Exception e)
            {
                ViewBag.Msg = e.Message;
            }
            return View();
        }
    }
}
