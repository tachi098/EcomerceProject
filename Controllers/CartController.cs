using EcomerceProject.Entities;
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
    public class CartController : Controller
    {
        private IProductServices services;

        public CartController(IProductServices services)
        {
            this.services = services;
        }
        public IActionResult addCart(int id)
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
                for (int i = 0; i < dataCart.Count ; i++)
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
                return RedirectToAction("UserIndex", controllerName: "Product");
            }
            return View();
        }




        public IActionResult UpdateCartDown(int id)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                var dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].product.id == id)
                    {
                        if (dataCart[i].quantity > 1)
                        {
                            dataCart[i].quantity -= 1;
                        }
                    }
                }
                ViewBag.carts = dataCart;
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                return View("ListCart");
            }
            return RedirectToAction("UserIndex", controllerName: "Product");
        }

        public IActionResult UpdateCartUp(int id)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                var dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].product.id == id)
                    {
                        dataCart[i].quantity += 1;
                    }
                }
                ViewBag.carts = dataCart;
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                return View("ListCart");
            }
            return RedirectToAction("UserIndex", controllerName: "Product");
        }
    }
}
