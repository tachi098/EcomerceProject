using DocumentFormat.OpenXml.Wordprocessing;
using EcomerceProject.Entities;
using EcomerceProject.Repositories;
using EcomerceProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceProject.Controllers.Admin
{
    public class ProductController : Controller
    {
        private IProductServices services;
        private ApplicationContext context;
        public ProductController(IProductServices services, ApplicationContext context)
        {
            this.services = services;
            this.context = context;
        }
        public IActionResult Index()
        {
            var products = services.GetProducts();
            return View(products);
        }

        public async Task<IActionResult> UserIndex(int? page, string sortOrder, string currentFilter, string searchString)
        {
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var products = context.Product.Select(p => p);
            int pageSize = 2;
            return View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), page ?? 1, pageSize));
            //return PartialView("_UserIndex", await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), page ?? 1, pageSize));
        }

    }
}
