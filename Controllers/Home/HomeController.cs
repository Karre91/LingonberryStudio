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
			string searchError;
			if (TempData.ContainsKey("searchError"))
				searchError = TempData["searchError"].ToString();

			return View();
        }

        [HttpPost]
        public IActionResult OfferingSearch(string searchArea)
        {
            if (ModelState.IsValid)
            {
                string tmp = searchArea.Trim();
                tmp = Regex.Replace(tmp, @"[\d-\D/g]", string.Empty); //tar bort siffror och tecken
                if (tmp == "")
                {
					TempData["searchError"] = "There is no city called \"" + searchArea + "\"";
					return RedirectToAction("Index");
                }
                else
                {
                    tmp = Regex.Replace(tmp, @"\s+", "-");
                    tmp = tmp.ToUpper();
                    return RedirectToAction("Search", "Adverts", new { city = tmp, search = "Offering" });
                }
            }
            else
            {
                return RedirectToAction("Search", "Adverts", new { city = searchArea, search = "Offering" });
            }
        }

        [HttpPost]
        public IActionResult LookingSearch(string searchArea)
        {
			if (ModelState.IsValid)
			{
				string tmp = searchArea.Trim();
				tmp = Regex.Replace(tmp, @"[\d-\D/g]", string.Empty); //tar bort siffror
                if (tmp == "")
				{
					TempData["searchError"] = "There is no city called \"" + searchArea + "\"";
					return RedirectToAction("Index");
				}
				else
				{
					tmp = Regex.Replace(tmp, @"\s+", "-");
					tmp = tmp.ToUpper();
					return RedirectToAction("Search", "Adverts", new { city = searchArea, search = "Looking" });
				}
			}
			else
			{
				return RedirectToAction("Search", "Adverts", new { city = searchArea, search = "Looking" });
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