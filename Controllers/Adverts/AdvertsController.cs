﻿using LingonberryStudio.Data;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LingonberryStudio.Controllers.Adverts
{
    public class AdvertsController : Controller
    {
        private readonly LingonberryDbContext _db;
        public readonly IWebHostEnvironment _Web;
        List<Advert> testList = new List<Advert>();
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
                TempData["list"] = JsonConvert.SerializeObject(filteredAds);
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

        private List<Advert> filterByBudget(string budgetMonth, string budgetWeek, int budget, List<Advert> originalList, List<Advert> goalList)
        {            
            if (budgetMonth != null || budgetWeek != null)
            {
                int weekBud = 0;
                int monthBud = 0;
                if (budgetMonth != null)
                {
                    weekBud = budget / 4;
                    goalList.AddRange(originalList.Where(a => a.Budgets.MonthOrWeek == ("Month")
                        && budget >= a.Budgets.Price
                        || a.Budgets.MonthOrWeek == ("Week")
                        && weekBud >= a.Budgets.Price).ToList());
                }
                if (budgetWeek != null)
                {
                    monthBud = budget * 4;
                    goalList.AddRange(originalList.Where(a => a.Budgets.MonthOrWeek == ("Month")
                    && monthBud >= a.Budgets.Price
                    || a.Budgets.MonthOrWeek == ("Week")
                    && budget >= a.Budgets.Price).ToList());
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
                foreach (var studio in workplaceList)
                {
                    if (studio != "Other")
                    {
                        goalList.AddRange(originalList.Where(w => w.WorkspaceDescription == studio).ToList());
                    }
                    else
                    {
                        goalList.AddRange(originalList.Where(f1 => notOther.All(f2 => f2 != f1.WorkspaceDescription)).ToList());
                    }
                }
            }
            return goalList;
        }

        [HttpPost]
        public IActionResult Filter(string budgetMonth, string budgetWeek, int budget, ICollection<string> studioList)
        {
            List<Advert> goalList = new();

            if (TempData["list"] != null)
            {
                var alreadyFilteredAds = JsonConvert.DeserializeObject<List<Advert>>(TempData["list"].ToString());

                goalList = filterByBudget(budgetMonth, budgetWeek, budget, alreadyFilteredAds, goalList);
                goalList = filterByWorkplace(studioList, alreadyFilteredAds, goalList);
            }
            else
            {
                var allAdverts = _db.Adverts
                    .Include(ads => ads.Measurements)
                    .Include(ads => ads.Amenities)
                    .Include(ads => ads.Budgets)
                    .Include(ads => ads.DatesAndTimes)
                    .Include(ads => ads.DatesAndTimes.Days)
                    .Include(ads => ads.Description)
                    .ToList();

                goalList = filterByBudget(budgetMonth, budgetWeek, budget, allAdverts, goalList);
                goalList = filterByWorkplace(studioList, allAdverts, goalList);
            }

            TempData["list"] = JsonConvert.SerializeObject(goalList);
            return RedirectToAction("Adverts", "Adverts");
        }
    }
}


