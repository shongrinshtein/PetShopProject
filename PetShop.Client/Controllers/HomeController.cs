#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Data.Models;
using PetShop.Service;

namespace PetShop.Client.Controllers
{
    public class HomeController : Controller
    {
        private IHomeService homeService;
        public HomeController(IHomeService homeService) => this.homeService = homeService;

        public IActionResult Index(string viewName = "ShowTopRated")
        {
            return View(homeService.GetTopTwoComments().Result);
        }


    }
}
