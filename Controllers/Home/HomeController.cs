using LingonberryStudio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace LingonberryStudio.Controllers.Home
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

        [HttpPost]
        public IActionResult OfferingSearch(string searchArea)
        {
            string tmp = searchArea.Trim();
            tmp = Regex.Replace(tmp, @"\s+", "-");
            tmp = Regex.Replace(tmp, @"[\d-]", string.Empty);
            tmp = tmp.ToUpper();      

            return RedirectToAction("Search", "Adverts", new { city = tmp, search = "Offering" } );
        }

		[HttpPost]
		public IActionResult LookingSearch(string searchArea)
		{
			//REGEX tjofräs?

			return RedirectToAction("Search", "Adverts", new { city = searchArea, search = "Looking" });
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