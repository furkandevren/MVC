﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class OrnekController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
