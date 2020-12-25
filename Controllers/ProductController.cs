using DinkToPdf;
using DinkToPdf.Contracts;
using DocumentFormat.OpenXml.Wordprocessing;
using EcomerceProject.Entities;
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

        public ProductController(IProductServices services, ApplicationContext context, IConverter converter)
        {
            this.services = services;
            this.context = context;
            _converter = converter;
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
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                //Out = @"D:\PDFCreator\Report.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                //HtmlContent = "<h1>Hello PDF</h1>",
                //Page = "http://localhost:52743/",
                Page = "http://localhost:52743/User/Login",
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            _converter.Convert(pdf);

            var file = _converter.Convert(pdf);
            return File(file, "application/pdf", "Report.pdf");
        }

    }
}
