using CoffeeShop.DALModels;
using CoffeeShop.DomainModels;
using CoffeeShop.Models.CoffeeShop;
using CoffeeShop.Services;
using CoffeeShop.ViewModels.CoffeeShop;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Controllers
{
    public class CoffeeShopController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly CoffeeShopContext _coffeeShopContext;

        public CoffeeShopController(CoffeeShopContext coffeeShopContext)
        {
            _coffeeShopContext = coffeeShopContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Start()
        {
            var viewModel = new StartViewModel();


            return View(viewModel);
        }
        public IActionResult DisplayInfo(StartViewModel model)
        {

            var displayModel = new DisplayViewModel();

            displayModel.DisplayName = model.FirstName;

            return View("Display", displayModel);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult MakeNewUser(UserViewModel u)
        {
            var user = new CoffeeDAL();
            user.Username = u.Username;
            user.Email = u.Email;
            user.PhoneNumber = u.PhoneNumber;
            user.Password = u.Password;

            //_coffeeShopContext.Users.Add(user);
            _coffeeShopContext.SaveChanges();


            return View("Index");
        }

        public IActionResult Login(UserViewModel u)
        {
            //var user = new CoffeeDAL();
            
            //if(u.Username == user.Username && u.Password == user.Password)
            //{
            //    return RedirectToAction("Shop", "Coffeeshop", user.UserID);
            //}

            return View();
        }

        public IActionResult Shop()
        {
            return View();
        }

        public IActionResult PurchaseItem(string itemID, int userID)
        {
            ItemsDAL item = LocateItemByID(itemID);
            //CoffeeDAL user = LocateUserByID(userID);

            //if(user.Funds < item.Price)
            //{
            //    return View("NoFunds");
            //}
            //else
            //{
            //    item.Quantity--;
            //    return View("Shop", itemID);

            //}
            return View();
        }

        public ItemsDAL LocateItemByID(string itemID)
        {
            ItemsDAL itemsDAL = _coffeeShopContext.Items
            .Where(items => items.itemID == itemID)
            .FirstOrDefault();

            return itemsDAL;
        }

        public string LocateUserByID(string ID)
        {
            var person = _coffeeShopContext.Users
            .Where(users => _userManager.GetUserName(User) == ID)
            .FirstOrDefault();

            var user = new UserViewModel();

            user.Username = person.UserName;

            return user.Username;
        }
    }
}
