using DinkToPdf;
using DinkToPdf.Contracts;
using DocumentFormat.OpenXml.Wordprocessing;
using EcomerceProject.Entities;
using EcomerceProject.Helpers;
using EcomerceProject.Repositories;
using EcomerceProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceProject.Controllers.Admin
{
    public class ProductController : Controller
    {
        private IProductServices services;
        private ApplicationContext context;
        private IConverter _converter;

        public ProductController(IProductServices services, ApplicationContext context, IConverter _converter)
        {
            this.services = services;
            this.context = context;
            this._converter = _converter;
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


        public IActionResult CreatePDF()
        {
            var page = "http://localhost:52743/User/Login";
            var file = Helper.PDF.Create(_converter, page);
            return File(file, "application/pdf", "Report.pdf");
        }

    }
}
