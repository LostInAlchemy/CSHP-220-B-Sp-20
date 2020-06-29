using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayCardGenerator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BDayCardForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BDayCardForm(Models.SenderInfo senderInfo)
        {
            if (ModelState.IsValid)
            {
                return View("BDayCardSent", senderInfo);
            }
            else
            {
                return View();
            }
        }
    }
}