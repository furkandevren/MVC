﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NoLayout()
        {
            return View();
        }
    }
}
