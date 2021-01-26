using CoffeeShop.Models.CoffeeShop;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Controllers
{
    public class CoffeeShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            var viewModel = new RegisterViewModel();


            return View(viewModel);
        }
        public IActionResult DisplayInfo(RegisterViewModel model)
        {

            var displayModel = new DisplayViewModel();

            displayModel.DisplayName = model.FirstName;

            return View("Display", displayModel);
        }
    }
}
