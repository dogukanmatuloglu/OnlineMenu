﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineMenu.UI.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
