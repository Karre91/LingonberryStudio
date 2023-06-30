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
    using Microsoft.Extensions.Caching.Memory;

    //using Microsoft.VisualBasic;
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly LingonberryDbContext db;
        private readonly IMemoryCache cache;

        public HomeController(ILogger<HomeController> logger, LingonberryDbContext db, IMemoryCache memoryCache)
        {
            this.logger = logger;
            this.db = db;
            this.cache = memoryCache;
        }

        public IActionResult Index()
        {
            //string cacheKey = "adverts";
            //if (!cache.TryGetValue(cacheKey, out var advert))
            //{
            //    // Data not in the cache, retrieve it from the database and add it to the cache
            //    advert = GetAdsInDB();
            //    if (advert != null)
            //    {
            //        cache.Set(cacheKey, advert, TimeSpan.FromMinutes(30)); // Cache for 30 minutes
            //    }
            //}

            ViewBag.CityNotFound = TempData["searchError"];
            return View();
        }

        [HttpPost]
        public IActionResult IndexSearch(string city, bool looking)
        {
            if (string.IsNullOrEmpty(city))
            {
                var emptySearch = TempData["searchError"] = "Search field was empty, please try again!";
                return RedirectToAction("Index", emptySearch);
            }

            return RedirectToAction("Adverts", "Adverts", new { city = city, offering = looking, hasFilter = true });
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

        private List<Advert> GetAdsInDB()
        {
            List<Advert> allAdsInDB = db.Adverts
            .OrderBy(p => p.TimeCreated).Reverse()
            .AsNoTracking()
            .ToList();

            return ExcludeOldAdsIds(allAdsInDB);
        }

        private List<Advert> ExcludeOldAdsIds(List<Advert> allAdsInDB)
        {
            var goalList = allAdsInDB.Except(allAdsInDB.Where(ad => (ad.TimeCreated.Date - DateTime.Now).Days! <= -180)).ToList();
            return goalList;
        }
    }
}