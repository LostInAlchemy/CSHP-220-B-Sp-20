using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Homework6.Models;

namespace Homework6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Index(Models.SenderInfo senderInfo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return View("Thanks", senderInfo);
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}
