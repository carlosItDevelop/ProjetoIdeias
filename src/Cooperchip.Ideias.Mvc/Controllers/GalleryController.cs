using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cooperchip.Ideias.Mvc.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult BasicGallery()
        {
            return View();
        }

        public IActionResult BootstrapCarusela()
        {
            return View();
        }

        public IActionResult SlickCarusela()
        {
            return View();
        }
    }
}