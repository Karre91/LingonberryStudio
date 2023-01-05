using LingonberryStudio.Data;
using LingonberryStudio.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Tar;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LingonberryStudio.Controllers.Adverts
{
    public class AdvertsController : Controller
    {
        private readonly LingonberryDbContext _db;
        public readonly IWebHostEnvironment _Web;
        List<Advert> allAdsInDB = new List<Advert>();
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
            if (TempData["allAdsInDB"] == null)
            {
                allAdsInDB = _db.Adverts
                .Include(ads => ads.Measurements)
                .Include(ads => ads.Amenities)
                .Include(ads => ads.Budgets)
                .Include(ads => ads.DatesAndTimes)
                .Include(ads => ads.DatesAndTimes.Days)
                .Include(ads => ads.Description)
                .ToList();
                TempData["allAdsInDB"] = JsonConvert.SerializeObject(allAdsInDB);
                TempData.Keep("allAdsInDB");
            }
            else
            {
                if (TempData["filteredList"] != null)
                {
                    var filteredAds = JsonConvert.DeserializeObject<List<Advert>>(TempData["filteredList"].ToString());
                    ViewBag.Total = filteredAds.Count();
                    TempData["filteredList"] = JsonConvert.SerializeObject(filteredAds);
                    TempData.Keep("allAdsInDB");

                    return View(filteredAds);
                }

                allAdsInDB = JsonConvert.DeserializeObject<List<Advert>>(TempData["allAdsInDB"].ToString());
                TempData["allAdsInDB"] = JsonConvert.SerializeObject(allAdsInDB);
                TempData.Keep("allAdsInDB");
            }

            ViewBag.Total = allAdsInDB.Count();
            return View(allAdsInDB);
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
                ad.City = ad.City.ToUpper();

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
            TempData.Remove("allAdsInDB");
            return RedirectToAction("Adverts");
        }

        [HttpPost]
        public IActionResult Filter(string MonthOrWeek, int budget, ICollection<string> studioList, string city, ICollection<string> amenitiesList, ICollection<string> daysList)
        {
            List<Advert> goalList = new();

            if (TempData["filteredList"] == null)
            {
                var allAdverts = JsonConvert.DeserializeObject<List<Advert>>(TempData["allAdsInDB"].ToString());
                goalList = filterByCity(city, allAdverts, goalList);
                goalList = filterByBudget(MonthOrWeek, budget, allAdverts, goalList);
                goalList = filterByWorkplace(studioList, allAdverts, goalList);
                goalList = filterByAmenities(amenitiesList, allAdverts, goalList);
                goalList = filterByDays(daysList, allAdverts, goalList);
            }
            else
            {
                var alreadyFilteredAds = JsonConvert.DeserializeObject<List<Advert>>(TempData["filteredList"].ToString());
                goalList = filterByCity(city, alreadyFilteredAds, goalList);
                goalList = filterByBudget(MonthOrWeek, budget, alreadyFilteredAds, goalList);
                goalList = filterByWorkplace(studioList, alreadyFilteredAds, goalList);
                goalList = filterByAmenities(amenitiesList, alreadyFilteredAds, goalList);
                goalList = filterByDays(daysList, alreadyFilteredAds, goalList);
            }

            TempData["filteredList"] = JsonConvert.SerializeObject(goalList);
            return RedirectToAction("Adverts", "Adverts");
        }

        private List<Advert> filterByCity(string city, List<Advert> originalList, List<Advert> goalList)
        {
            if (city != null)
            {
                city = city.ToUpper();
                goalList.AddRange(originalList.Where(ad => ad.City == city));
            }

            return goalList;
        }

        private List<Advert> filterByBudget(string MonthOrWeek, int budget, List<Advert> originalList, List<Advert> goalList)
        {
            if (MonthOrWeek != null)
            {
                List<Advert> tempList = new();
                if (goalList.Count > 0) { tempList = goalList; }
                else { tempList = originalList; }

                //FIX NEEDED
                int weekBud = 0;
                int monthBud = 0;
                if (MonthOrWeek == "Month")
                {
                    weekBud = budget / 4;
                    goalList = tempList.Where(a => a.Budgets.MonthOrWeek == ("Month")
                        && budget >= a.Budgets.Price
                        || a.Budgets.MonthOrWeek == ("Week")
                        && weekBud >= a.Budgets.Price).ToList();
                }
                if (MonthOrWeek == "Week")
                {
                    monthBud = budget * 4;
                    goalList = tempList.Where(a => a.Budgets.MonthOrWeek == ("Month")
                    && monthBud >= a.Budgets.Price
                    || a.Budgets.MonthOrWeek == ("Week")
                    && budget >= a.Budgets.Price).ToList();
                }
            }

            return goalList;
        }

        private List<Advert> filterByWorkplace(ICollection<string> workplaceList, List<Advert> originalList, List<Advert> goalList)
        {
            if (workplaceList.Count > 0)
            {
                List<string> notOther = new List<string>()
                {
                "Music Studio", "Art Studio", "Photo Studio", "Dance Rehersal Studio",
                "Ceramics Studio", "Painting Workshop"
                };
                List<Advert> tempList = new();
                if (goalList.Count > 0) { tempList = goalList; }
                else { tempList = originalList; }

                foreach (var studio in workplaceList)
                {
                    if (studio != "Other")
                    {
                        goalList = tempList.Where(w => w.WorkspaceDescription == studio).ToList();
                    }
                    else
                    {
                        goalList = tempList.Where(f1 => notOther.All(f2 => f2 != f1.WorkspaceDescription)).ToList();
                    }
                }
            }
            return goalList;
        }

        private List<Advert> filterByAmenities(ICollection<string> amenitiesList, List<Advert> originalList, List<Advert> goalList)
        {
            if (amenitiesList.Count > 0)
            {
                List<Advert> tempList = new();
                if (goalList.Count > 0) { tempList = goalList; }
                else { tempList = originalList; }

                goalList = tempList.Where(a => a.Amenities.Kitchen == true
                    && amenitiesList.Contains("Parking")
                    || a.Amenities.AirCon == true
                    && amenitiesList.Contains("AirCon")
                    || a.Amenities.Kitchen == true
                    && amenitiesList.Contains("Kitchen")
                    || a.Amenities.NaturalLight == true
                    && amenitiesList.Contains("NaturalLight")
                    || a.Amenities.AcousticTreatment == true
                    && amenitiesList.Contains("AcousticTreatment")
                    || a.Amenities.RunningWater == true
                    && amenitiesList.Contains("RunningWater")
                    || a.Amenities.Storage == true
                    && amenitiesList.Contains("Storage")).ToList();
            }
            return goalList;
        }

        private List<Advert> filterByDays(ICollection<string> daysList, List<Advert> originalList, List<Advert> goalList)
        {
            if (daysList.Count > 0)
            {
                List<Advert> tempList = new();
                if (goalList.Count > 0) { tempList = goalList; }
                else { tempList = originalList; }

                goalList = tempList.Where(a => a.DatesAndTimes.Days.Monday == true
                   && daysList.Contains("Monday")
                   || a.DatesAndTimes.Days.Tuesday == true
                   && daysList.Contains("Tuesday")
                   || a.DatesAndTimes.Days.Wednesday == true
                   && daysList.Contains("Wednesday")
                   || a.DatesAndTimes.Days.Thursday == true
                   && daysList.Contains("Thursday")
                   || a.DatesAndTimes.Days.Friday == true
                   && daysList.Contains("Friday")
                   || a.DatesAndTimes.Days.Saturday == true
                   && daysList.Contains("Saturday")
                   || a.DatesAndTimes.Days.Sunday == true
                   && daysList.Contains("Sunday")).ToList();
            }

            return goalList;
        }
        
        public IActionResult Empty()
        {
            TempData.Remove("filteredList");
            return RedirectToAction("Adverts", "Adverts");
        }
    }
}


