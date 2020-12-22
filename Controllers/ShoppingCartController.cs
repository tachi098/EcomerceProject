using EcomerceProject.Entities;
using EcomerceProject.Repositories;
using EcomerceProject.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceProject.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationContext context;
        private IProductServices services;
        public ShoppingCartController(ApplicationContext context, IProductServices services)
        {
            this.context = context;
            this.services = services;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddShoppingCart(int id)
        {
            var user = HttpContext.Session.GetString("user");
            if (user == null)
            {
                var cart = HttpContext.Session.GetString("cart");
                if (cart == null)
                {
                    var product = services.GetProduct(id);
                    List<Cart> listCart = new List<Cart>()
                {
                    new Cart{ product = product, quantity = 1}
                };
                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(listCart));
                }
                else
                {
                    List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                    bool check = true;
                    for (int i = 0; i < dataCart.Count; i++)
                    {
                        if (dataCart[i].product.id == id)
                        {
                            dataCart[i].quantity++;
                            check = false;
                        }
                    }
                    if (check)
                    {
                        dataCart.Add(new Cart
                        {
                            product = services.GetProduct(id),
                            quantity = 1
                        });
                    }
                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                }
                return RedirectToAction("UserIndex", controllerName: "Product");
            }
            else
            {
                User u = JsonConvert.DeserializeObject<User>(user);
                var scart = context.ShoppingCart.SingleOrDefault(s => s.userid.Equals(u.id));
                if (scart == null)
                {
                    var p = services.GetProduct(id);
                    List<Cart> crt = new List<Cart>();
                    crt.Add(new Cart { product = p, quantity = 1 });
                    var cnt = JsonConvert.SerializeObject(crt);
                    ShoppingCart shopping = new ShoppingCart() { userid = u.id, content = cnt };
                    context.ShoppingCart.Add(shopping);
                    context.SaveChanges();
                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(crt));
                    return RedirectToAction("UserIndex", controllerName: "Product");
                }
                else
                {
                    var dataCart = JsonConvert.DeserializeObject<List<Cart>>(scart.content);
                    bool check = true;
                    for (int i = 0; i < dataCart.Count; i++)
                    {
                        if (dataCart[i].product.id == id)
                        {
                            dataCart[i].quantity++;
                            check = false;
                            var newDataCart = JsonConvert.SerializeObject(dataCart);
                            scart.content = newDataCart;
                            context.SaveChanges();
                            HttpContext.Session.SetString("cart", newDataCart);
                        }
                    }
                    if (check)
                    {
                        dataCart.Add(new Cart
                        {
                            product = services.GetProduct(id),
                            quantity = 1
                        });
                        var newDataCart = JsonConvert.SerializeObject(dataCart);
                        scart.content = newDataCart;
                        context.SaveChanges();
                        HttpContext.Session.SetString("cart", newDataCart);
                    }

                }

                    return RedirectToAction("UserIndex", controllerName: "Product");
                }
            }

        public IActionResult ListCart()
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                if (dataCart.Count > 0)
                {
                    ViewBag.carts = dataCart;
                    return View();
                }
            }
            return RedirectToAction("UserIndex", controllerName: "Product");
        }

        public IActionResult DeleteCart(int id)
        {
            var u = HttpContext.Session.GetString("user");
            if (u == null)
            {
                var cart = HttpContext.Session.GetString("cart");
                if (cart != null)
                {
                    var dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                    for (int i = 0; i < dataCart.Count; i++)
                    {
                        if (dataCart[i].product.id == id)
                        {
                            dataCart.RemoveAt(i);
                        }

                    }
                    ViewBag.carts = dataCart;
                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                    return RedirectToAction("ListCart", controllerName: "ShoppingCart");
                }
            }
            else
            {
                var user = JsonConvert.DeserializeObject<User>(u);
                var dataCart = context.ShoppingCart.SingleOrDefault(s => s.userid.Equals(user.id));
                var oldCart = JsonConvert.DeserializeObject<List<Cart>>(dataCart.content);
                for (int i = 0; i < oldCart.Count; i++)
                {
                    if (oldCart[i].product.id == id)
                    {
                        oldCart.RemoveAt(i);
                        var newCart = JsonConvert.SerializeObject(oldCart);
                        dataCart.content = newCart;
                        context.SaveChanges();
                        HttpContext.Session.SetString("cart", newCart);
                        return RedirectToAction("ListCart", controllerName: "ShoppingCart");
                    }
                }
            }
            return RedirectToAction("UserIndex", controllerName: "Product");
        }
    }
}
