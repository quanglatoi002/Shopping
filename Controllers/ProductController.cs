﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace Shopping_Tutorial.Controllers
{
	public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }
    }

}
