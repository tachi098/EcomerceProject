using EcomerceProject.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceProject.Controllers
{
    public class BarcodesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string barcode)
        {
            ViewBag.BarcodeImage = Helper.Barcode.Set(barcode);
            return View();
        }
    }
}
