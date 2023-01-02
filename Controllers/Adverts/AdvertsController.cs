using LingonberryStudio.Data;
using LingonberryStudio.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Tar;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LingonberryStudio.Controllers.Adverts
{
    public class AdvertsController : Controller
    {
        private readonly LingonberryDbContext _db;
        public readonly IWebHostEnvironment _Web;
        List<Advert> testList = new List<Advert>();
        List<Advert> SomeList = new List<Advert>();
        public AdvertsController(LingonberryDbContext db, IWebHostEnvironment web)
        {
            _db = db;
            _Web = web;
        }

        //[HttpGet("Adverts")]
        //[ActionName("Adverts")]
        //public IActionResult Adverts()
        //{
        //    //var ads = _db.Adverts
        //    //    .Include(ads => ads.Measurements)
        //    //    .Include(ads => ads.Amenities)
        //    //    .Include(ads => ads.Budgets)
        //    //    .Include(ads => ads.DatesAndTimes)
        //    //    .Include(ads => ads.DatesAndTimes.Days)
        //    //    .Include(ads => ads.Description)
        //    //    .ToList();
        //    //ViewBag.Total = ads.Count();
        //    //return View(ads);

        //    testList = _db.Adverts
        //        .Include(ads => ads.Measurements)
        //        .Include(ads => ads.Amenities)
        //        .Include(ads => ads.Budgets)
        //        .Include(ads => ads.DatesAndTimes)
        //        .Include(ads => ads.DatesAndTimes.Days)
        //        .Include(ads => ads.Description)
        //        .ToList();

        //    ViewBag.Total = testList.Count();
        //    return View(testList);
        //}

        //[ActionName("FilteredAdverts")]
        public IActionResult Adverts()
        {
            if (TempData["list"] != null)
            {
                var filteredAds = JsonConvert.DeserializeObject<List<Advert>>(TempData["list"].ToString());
                ViewBag.Total = filteredAds.Count();
                return View(filteredAds);
            }
            testList = _db.Adverts
                .Include(ads => ads.Measurements)
                .Include(ads => ads.Amenities)
                .Include(ads => ads.Budgets)
                .Include(ads => ads.DatesAndTimes)
                .Include(ads => ads.DatesAndTimes.Days)
                .Include(ads => ads.Description)
                .ToList();

            ViewBag.Total = testList.Count();
            return View(testList);
        }

        [HttpGet("AdvertSearch")]
        public IActionResult Search(string city, string search)
        {
            var adverts = new List<Advert>();
            if (city == null)
            {
                adverts = _db.Adverts
                    .Where(ad => ad.OfferingLooking == search)
                    .Include(ads => ads.Measurements)
                    .Include(ads => ads.Amenities)
                    .Include(ads => ads.Budgets)
                    .Include(ads => ads.DatesAndTimes)
                    .Include(ads => ads.DatesAndTimes.Days)
                    .Include(ads => ads.Description)
                    .ToList();
            }
            else
            {
                adverts = _db.Adverts
                    .Where(ad => ad.OfferingLooking == search && ad.City == city)
                    .Include(ads => ads.Measurements)
                    .Include(ads => ads.Amenities)
                    .Include(ads => ads.Budgets)
                    .Include(ads => ads.DatesAndTimes)
                    .Include(ads => ads.DatesAndTimes.Days)
                    .Include(ads => ads.Description)
                    .ToList();
            }
            return View(adverts);
        }

        public IActionResult Form()
        {
            return PartialView("_FormPartial");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult CreateAd(Advert ad)
        {
            //var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                //REGEX HERE
                if (ad.Description.formFile != null)
                {
                    ad.Description.ImgUrl = "StudioImages/" + Guid.NewGuid().ToString() + "_" + ad.Description.formFile.FileName;
                    var path = Path.Combine(_Web.WebRootPath, ad.Description.ImgUrl);
                    ad.Description.formFile.CopyToAsync(new FileStream(path, FileMode.Create));
                }
                else
                {
                    ad.Description.ImgUrl = "StudioImages/Test.jpg";
                }
                _db.Adverts.Add(ad);
                _db.SaveChanges();
            }
            return RedirectToAction("Adverts");
        }

        [HttpPost]
        public IActionResult Filter(string budgetMonth, string budgetWeek, int budget, ICollection<string> studioList)
        {
            var adverts = _db.Adverts
                    .Include(ads => ads.Measurements)
                    .Include(ads => ads.Amenities)
                    .Include(ads => ads.Budgets)
                    .Include(ads => ads.DatesAndTimes)
                    .Include(ads => ads.DatesAndTimes.Days)
                    .Include(ads => ads.Description)
                    .ToList();

            List<Advert> ad2 = new();
            if (budgetMonth != null || budgetWeek != null)
            {
                int totBudget = 0;
                if (budgetMonth != null)
                {
                    totBudget = budget / 4;
                    ad2 = adverts.Where(ad => ad.Budgets.MonthOrWeek? = "Month");
                }
                if (budgetWeek != null)
                {
                    totBudget = budget * 4;
                }


                
            }


            TempData["list"] = JsonConvert.SerializeObject(adverts);

            //    IEnumerable<Advert> testFiltered;
            //foreach (var studio in studioList)
            //{
            //    testFiltered = testList.Where(workplace => workplace.WorkspaceDescription == studio);
            //}





            //var testFilterd = testList.Where(ad => ad.Budgets.Price < budget);









            return RedirectToAction("Adverts", "Adverts");
        }
    }
}


