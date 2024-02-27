﻿using LanchesMac.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LanchesMac.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            //TempData["Nome"] = "Pedro";
            return View();
        }
        public IActionResult Demo()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}