namespace LingonberryStudio.Controllers.Home
{
    using System.Diagnostics;
    using System.Text;
    using System.Text.RegularExpressions;
    using LingonberryStudio.Models;
    using LingonberryStudio.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Microsoft.VisualBasic;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index(string cityNotFound)
        {
            return View(cityNotFound);
        }

        [HttpPost]
        public IActionResult OfferingSearch(string searchArea)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Search", "Adverts", new { city = searchArea, search = "Offering" });
            }
            else
            {
                var cityNotFound = TempData["searchError"] = "Search field was empty, please try again!";
                return RedirectToAction("Index", cityNotFound);
            }
        }

        [HttpPost]
        public IActionResult LookingSearch(string searchArea)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Search", "Adverts", new { city = searchArea, search = "Looking" });
            }
            else
            {
                var cityNotFound = TempData["searchError"] = "Search field was empty, please try again!";
                return RedirectToAction("Index", cityNotFound);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}