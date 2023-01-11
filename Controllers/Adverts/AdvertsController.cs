using LingonberryStudio.Data;
using LingonberryStudio.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Tar;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using LingonberryStudio.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

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
        private List<Advert> GetAdsInDB()
        {
            allAdsInDB = _db.Adverts
                    .Include(ads => ads.Measurements)
                    .Include(ads => ads.Amenities)
                    .Include(ads => ads.Budgets)
                    .Include(ads => ads.DatesAndTimes)
                    .Include(ads => ads.DatesAndTimes.Days)
                    .Include(ads => ads.Description)
                    .AsNoTracking()
                    .ToList();

            allAdsInDB = excludeOldAds(allAdsInDB);
            //TempData["allAdsInDB"] = JsonConvert.SerializeObject(allAdsInDB);
            //TempData.Keep("allAdsInDB");

            return allAdsInDB;
        }
        //public IActionResult Adverts()
        //{
        //    AdvertViewMoldel advertViewModel = new();
        //    advertViewModel.AdvertList = GetAdsInDB();

        //    //if (TempData["allAdsInDB"] == null)
        //    //         {
        //    //             allAdsInDB = GetAdsInDB();
        //    //             ViewBag.hasFiltered = false;
        //    //         }
        //    //         else
        //    //         {
        //    //             if (TempData["filteredList"] != null)
        //    //             {
        //    //                 var filteredAds = JsonConvert.DeserializeObject<List<Advert>>(TempData["filteredList"].ToString());

        //    //                 ViewBag.Total = filteredAds?.Count();
        //    //                 ViewBag.hasFiltered = true;

        //    //                 ViewBag.monday = TempData["monday"];
        //    //                 ViewBag.tuesday = TempData["tuesday"];
        //    //                 ViewBag.wednesday = TempData["wednesday"];
        //    //                 ViewBag.thursday = TempData["thursday"];
        //    //                 ViewBag.friday = TempData["friday"];
        //    //                 ViewBag.saturday = TempData["saturday"];
        //    //                 ViewBag.sunday = TempData["sunday"];

        //    //                 ViewBag.parking = TempData["parking"];
        //    //                 ViewBag.airCon = TempData["airCon"];
        //    //                 ViewBag.kitchen = TempData["kitchen"];
        //    //                 ViewBag.naturalLight = TempData["naturalLight"];
        //    //                 ViewBag.aucusticTreatment = TempData["aucusticTreatment"];
        //    //                 ViewBag.runningWater = TempData["runningWater"];
        //    //                 ViewBag.storage = TempData["storage"];
        //    //                 ViewBag.other = TempData["other"];

        //    //                 TempData["filteredList"] = JsonConvert.SerializeObject(filteredAds);
        //    //                 TempData.Keep("allAdsInDB");
        //    //                 return View(filteredAds);
        //    //             }

        //    //             allAdsInDB = JsonConvert.DeserializeObject<List<Advert>>(TempData["allAdsInDB"].ToString());
        //    //             TempData["allAdsInDB"] = JsonConvert.SerializeObject(allAdsInDB);
        //    //             TempData.Keep("allAdsInDB");

        //    //             ViewBag.hasFiltered = false;
        //    //         }


        //    ViewBag.Total = advertViewModel.AdvertList.Count();
        //    return View(advertViewModel);
        //}

        [HttpGet]
        public IActionResult Adverts(AdvertViewMoldel a)
        {
            AdvertViewMoldel advertViewModel = new();
            advertViewModel.AdvertList = GetAdsInDB();

            if (a.OfferingLooking != null)
            {
                advertViewModel.OfferingLooking = a.OfferingLooking;
                Filter(a);
            }

            //ViewBag.Total = advertViewModel.AdvertList.Count();
            return View(advertViewModel);
        }

        private List<Advert> excludeOldAds(List<Advert> allAdsInDB)
        {
            var goalList = allAdsInDB.Except(allAdsInDB.Where(ad => (ad.TimeCreated.Date - DateTime.Now).Days! <= -60)).ToList();
            return goalList;
        }

        [HttpGet("AdvertSearch")]
        public IActionResult Search(string city, string search)
        {
            var adverts = new List<Advert>();
            if (TempData["allAdsInDB"] == null)
            {
                var allAds = GetAdsInDB();
            }
            else
            {
                var allAdsInDB = JsonConvert.DeserializeObject<List<Advert>>(TempData["allAdsInDB"].ToString());
                if (city == null)
                {
                    adverts = allAdsInDB.Where(ad => ad.OfferingLooking == search).ToList();
                }
                else
                {
                    adverts = allAdsInDB.Where(ad => ad.OfferingLooking == search && ad.City == city).ToList();
                }
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
                ad.City = ad.City?.ToUpper();

                if (ad.Description.formFile != null)
                {
                    ad.Description.ImgUrl = "StudioImages/" + Guid.NewGuid().ToString() + "_" + ad.Description.formFile.FileName;
                    var path = Path.Combine(_Web.WebRootPath, ad.Description.ImgUrl);
                    ad.Description.formFile.CopyToAsync(new FileStream(path, FileMode.Create));
                }
                else
                {
                    ad.Description.ImgUrl = "StudioImages/handshake.jpg";
                }
               
                _db.Adverts.Add(ad);
                _db.SaveChanges();
                return RedirectToAction("Adverts");
            }
            //TempData.Remove("allAdsInDB");
            return PartialView("_FormPartial",ad);
        }

        [HttpGet]
        public IActionResult Filter(AdvertViewMoldel a)
        {
            //List<bool> checkedDays = new() { monday, tuesday, wednesday, thursday, friday, saturday, sunday };
            //List<bool> checkedAmenities = new() { parking, airCon, kitchen, naturalLight, aucusticTreatment, runningWater, storage, other };
            //List<bool> checkedStudios = new() { a.MusikStudio, a.ArtStudio, a.PhotoStudio, a.DanceRehersalStudio, a.CeramicsStudio, a.PaintingWorkshop, a.OtherStudio };
            //List<string> studioStrings = new List<string>() { "Music Studio", "Art Studio", "Photo Studio", "Dance Rehersal Studio", "Ceramics Studio", "Painting Workshop", "Other" };
            //List<string> checkedStudioStrings = new List<string>();
            //for (int i = 0; i < checkedStudios.Count; i++)
            //{
            //    if (checkedStudios[i])
            //    {
            //        checkedStudioStrings.Add(studioStrings[i]);
            //    }
            //}

            if (a.City != null) { a.City = a.City.ToUpper(); }
            int weekBud = 0, monthBud = 0;
            if (a.MonthOrWeek == "Month") { weekBud = a.Budget / 4; monthBud = a.Budget; }
            if (a.MonthOrWeek == "Week") { monthBud = a.Budget * 4; weekBud = a.Budget; }

            var cityFilter = _db.Adverts    
                .Where(ad => ad.Amenities.Parking == a.Parking)
                .Where(ad => ad.OfferingLooking == a.OfferingLooking || a.OfferingLooking == null)
                .Where(ad => ad.City != null && ad.City == a.City || a.City == null)
                .Where(ad => ad.Budgets.MonthOrWeek != null && ad.Budgets.MonthOrWeek == "Month" && ad.Budgets.Price <= monthBud
                || ad.Budgets.MonthOrWeek != null && ad.Budgets.MonthOrWeek == "Week" && ad.Budgets.Price <= weekBud
                || a.MonthOrWeek == null)

                .Include(ads => ads.Measurements)
                    .Include(ads => ads.Amenities)
                    .Include(ads => ads.Budgets)
                    .Include(ads => ads.DatesAndTimes)
                    .Include(ads => ads.DatesAndTimes.Days)
                    .Include(ads => ads.Description)
                    .AsNoTracking()
                    .ToList();


            return RedirectToAction("Adverts", "Adverts");
            //if (TempData["filteredList"] == null)
            //{
            //List<Advert>? allAdsInDBList = JsonConvert.DeserializeObject<List<Advert>?>(TempData["allAdsInDB"].ToString());
            //}
            //else
            //{
            //    advertList = JsonConvert.DeserializeObject<List<Advert>>(TempData["filteredList"].ToString());
            //}

            //var goalList = filterByCity(city);
            //goalList = filterByBudget(MonthOrWeek, budget);
            //goalList = filterByWorkplace(studioList, allAdsInDBList, goalList);
            //goalList = filterByAmenities(checkedAmenities, allAdsInDBList, goalList);
            //goalList = filterByDays(checkedDays, allAdsInDBList, goalList);

            //TempData["filteredList"] = JsonConvert.SerializeObject(goalList);

        }

        private List<Advert> filterByCity(string city/*, List<Advert> originalList, List<Advert> goalList*/)
        {
            if (city != null)
            {
                city = city.ToUpper();
            }

            //var cityFilter = _db.Adverts.Where(ad => ad.City != null && ad.City == city || ad.City == null)
            //    .Select(ad => new
            //    {
            //        Measurement = ad.Measurements,
            //        Amenities = ad.Amenities,
            //        Budgets = ad.Budgets,
            //        DatesAndTimes = ad.DatesAndTimes,
            //        Days = ad.DatesAndTimes.Days,
            //        Descriptions = ad.Description
            //    })
            //    .AsNoTracking()
            //        .ToList();



            var cityFilter = _db.Adverts.Where(ad => ad.City != null && ad.City == city || ad.City == null)
                    .Include(ads => ads.Measurements)
                    .Include(ads => ads.Amenities)
                    .Include(ads => ads.Budgets)
                    .Include(ads => ads.DatesAndTimes)
                    .Include(ads => ads.DatesAndTimes.Days)
                    .Include(ads => ads.Description)
                    .AsNoTracking()
                    .ToList();

            return cityFilter;
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

        private List<Advert> filterByAmenities(List<bool> checkedAmenities, List<Advert> originalList, List<Advert> goalList)
        {
            TempData["parking"] = checkedAmenities[0];
            TempData["airCon"] = checkedAmenities[1];
            TempData["kitchen"] = checkedAmenities[2];
            TempData["naturalLight"] = checkedAmenities[3];
            TempData["aucusticTreatment"] = checkedAmenities[4];
            TempData["runningWater"] = checkedAmenities[5];
            TempData["storage"] = checkedAmenities[6];
            TempData["other"] = checkedAmenities[7];

            if (checkedAmenities.Contains(true))
            {
                List<Advert> tempList = new();

                foreach (var ad in originalList)
                {
                    var d = ad.Amenities;
                    var thisAdsAmenitiesList = d.GetList();
                    bool hasAtleastOne = false;
                    for (int i = 0; i < thisAdsAmenitiesList.Count; i++)
                    {
                        if (checkedAmenities[i] == true && thisAdsAmenitiesList[i] == true)
                        {
                            hasAtleastOne = true;
                        }
                    }
                    if (hasAtleastOne)
                    {
                        tempList.Add(ad);
                    }
                    if (checkedAmenities[7] == true && d.Other != null)
                    {
                        tempList.Add(ad);
                    }
                }

                tempList = tempList.Except(goalList).ToList();
                goalList.AddRange(tempList);
            }
            return goalList;
        }

        private List<Advert> filterByDays(List<bool> checkedDays, List<Advert> originalList, List<Advert> goalList)
        {
            TempData["monday"] = checkedDays[0];
            TempData["tuesday"] = checkedDays[1];
            TempData["wednesday"] = checkedDays[2];
            TempData["thursday"] = checkedDays[3];
            TempData["friday"] = checkedDays[4];
            TempData["saturday"] = checkedDays[5];
            TempData["sunday"] = checkedDays[6];

            if (checkedDays.Contains(true))
            {
                List<Advert> tempList = new();

                foreach (var ad in originalList)
                {
                    var d = ad.DatesAndTimes.Days;
                    var thisAdsDaysList = d.GetList();
                    bool hasAtleastOne = false;
                    for (int i = 0; i < thisAdsDaysList.Count; i++)
                    {
                        if (thisAdsDaysList[i] == true && checkedDays[i] == true)
                        {
                            hasAtleastOne = true;
                        }
                    }
                    if (hasAtleastOne)
                    {
                        tempList.Add(ad);
                    }
                }

                tempList = tempList.Except(goalList).ToList();
                goalList.AddRange(tempList);
            }

            return goalList;
        }

        public IActionResult Empty()
        {
            TempData["filtering"] = false;

            return RedirectToAction("Adverts", "Adverts");
        }
    }
}


