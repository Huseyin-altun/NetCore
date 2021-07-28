using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartyInvitesFriend2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvitesFriend2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Form()
        {
            return View();

        }


        [HttpPost]
        public ViewResult Form(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
            return View("Thanks", guestResponse);
            }
            else { 
                return View(); 
            }
        }
        public ViewResult ListResponses() {
            return View(Repository.Responses.Where(r => r.WillAttend == true)); 
        }



    }
}
