﻿using Microsoft.AspNet.Mvc;

namespace IdentityRight.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult About()
        {
            //ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "How you can contact us.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
