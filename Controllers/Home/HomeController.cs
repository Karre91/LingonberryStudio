namespace LingonberryStudio.Controllers.Home
{
    using System.Diagnostics;
    using System.Text;
    using System.Text.RegularExpressions;
    using LingonberryStudio.Data;
    using LingonberryStudio.Data.Entities;
    using LingonberryStudio.Models;
    using LingonberryStudio.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Microsoft.VisualBasic;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly LingonberryDbContext db;

        public HomeController(ILogger<HomeController> logger, LingonberryDbContext db)
        {
            this.logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            ViewBag.CityNotFound = TempData["searchError"];
            return View();
        }

        [HttpPost]
        public IActionResult IndexSearch(string city, bool offeringMine)
        {
            if (string.IsNullOrEmpty(city))
            {
                var emptySearch = TempData["searchError"] = "Search field was empty, please try again!";
                return RedirectToAction("Index", emptySearch);
            }

            return RedirectToAction("Adverts", "Adverts", new { city = city, offering = offeringMine, hasFilter = true });
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