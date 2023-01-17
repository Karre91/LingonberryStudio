﻿using LingonberryStudio.Data;
using LingonberryStudio.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LingonberryStudio.ViewModels;

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

        private List<Advert> GetAdsInDB()
        {
            allAdsInDB = _db.Adverts
                    .Include(ads=> ads.WorkPlace)
                    .ThenInclude(ads=>ads.AmenityTypes)
                    .Include(ads => ads.WorkPlace)
                    .ThenInclude(ads => ads.TimeFrames)
                    .AsNoTracking()
                    .ToList();

            allAdsInDB = excludeOldAds(allAdsInDB);
            return allAdsInDB;
        }

        private List<Advert> excludeOldAds(List<Advert> allAdsInDB)
        {
            var goalList = allAdsInDB.Except(allAdsInDB.Where(ad => (ad.TimeCreated.Date - DateTime.Now).Days! <= -60)).ToList();
            return goalList;
        }

        [HttpGet]
        public IActionResult Adverts(AdvertViewMoldel? viewModel)
        {
            AdvertViewMoldel advertViewModel = new();
            if (viewModel.AdvertList == null)
            {
                advertViewModel.AdvertList = GetAdsInDB();
            }
            if (viewModel.Filter != null)
            {
                advertViewModel.AdvertList = Filter(viewModel);                
            }

            ViewBag.Total = advertViewModel.AdvertList.Count();
            return View(advertViewModel);
        }

        public List<Advert> Filter(AdvertViewMoldel? viewModel)
        {
            if (viewModel.Filter.City != null) { viewModel.Filter.City = viewModel.Filter.City.ToUpper(); }

            //if (a.Filter.Budgets.Month) { weekBud = a.Filter.Budgets.Price / 4; monthBud = a.Filter.Budgets.Price; }
            //if (a.Filter.Budgets.Week) { monthBud = a.Filter.Budgets.Price * 4; weekBud = a.Filter.Budgets.Price; }
            int weekBud = 0, monthBud = 0;




            var filtered = _db.Adverts
                    .Where(ad => ad.Offering == viewModel.Filter.Offering || ad.Offering != viewModel.Filter.Looking || ad.Offering == viewModel.Filter.Offering && ad.Offering != viewModel.Filter.Looking)
                    
                    //.Where(ad => ad.Budgets.MonthOrWeek != null && ad.Budgets.MonthOrWeek == "Month" && ad.Budgets.Price <= monthBud
                    //|| ad.Budgets.MonthOrWeek != null && ad.Budgets.MonthOrWeek == "Week" && ad.Budgets.Price <= weekBud
                    //|| a.MonthOrWeek == null)
                    .Include(ads => ads.WorkPlace)
                    .Where(ad => ad.WorkPlace.City == viewModel.Filter.City ||  viewModel.Filter.City == null)
                    .Include(ads => ads.WorkPlace)
                    .ThenInclude(ads => ads.TimeFrames)
                    .Include(ads => ads.WorkPlace).ThenInclude(ads => ads.AmenityTypes)
                    .AsNoTracking()
                    .ToList();
            return filtered;

        }

        //[HttpGet("AdvertSearch")]
        //public IActionResult Search(string city, string search)
        //{
        //    var adverts = new List<Advert>();
        //    if (TempData["allAdsInDB"] == null)
        //    {
        //        var allAds = GetAdsInDB();
        //    }
        //    else
        //    {
        //        var allAdsInDB = JsonConvert.DeserializeObject<List<Advert>>(TempData["allAdsInDB"].ToString());
        //        if (city == null)
        //        {
        //            adverts = allAdsInDB.Where(ad => ad.OfferingLooking == search).ToList();
        //        }
        //        else
        //        {
        //            adverts = allAdsInDB.Where(ad => ad.OfferingLooking == search && ad.City == city).ToList();
        //        }
        //    }

        //    return View(adverts);
        //}

        public IActionResult Form()
        {
            return PartialView("_FormPartial");
        }

        //public IActionResult Filter()
        //{
        //    return PartialView("_FilterPartial");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAd(Advert ad)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                ad.WorkPlace.City = ad.WorkPlace.City?.ToUpper();

                if (ad.WorkPlace.FormFile != null)
                {
                    ad.WorkPlace.ImgUrl = "StudioImages/" + Guid.NewGuid().ToString() + "_" + ad.WorkPlace.FormFile.FileName;
                    var path = Path.Combine(_Web.WebRootPath, ad.WorkPlace.ImgUrl);
                    ad.WorkPlace.FormFile.CopyToAsync(new FileStream(path, FileMode.Create));
                }
                else
                {
                    // if offering == true osv
                    ad.WorkPlace.ImgUrl = "StudioImages/handshake.jpg";
                }

                _db.Adverts.Add(ad);
                _db.SaveChanges();
                return RedirectToAction("Adverts");
            }
            return PartialView("_FormPartial", ad);
        }




        //private List<Advert> filterByCity(string city/*, List<Advert> originalList, List<Advert> goalList*/)
        //{
        //    if (city != null)
        //    {
        //        city = city.ToUpper();
        //    }

        //    //var cityFilter = _db.Adverts.Where(ad => ad.City != null && ad.City == city || ad.City == null)
        //    //    .Select(ad => new
        //    //    {
        //    //        Measurement = ad.Measurements,
        //    //        Amenities = ad.Amenities,
        //    //        Budgets = ad.Budgets,
        //    //        DatesAndTimes = ad.DatesAndTimes,
        //    //        Days = ad.DatesAndTimes.Days,
        //    //        Descriptions = ad.Description
        //    //    })
        //    //    .AsNoTracking()
        //    //        .ToList();



        //    var cityFilter = _db.Adverts.Where(ad => ad.City != null && ad.City == city || ad.City == null)
        //            .Include(ads => ads.Measurements)
        //            .Include(ads => ads.Amenities)
        //            .Include(ads => ads.Budgets)
        //            .Include(ads => ads.DatesAndTimes)
        //            .Include(ads => ads.DatesAndTimes.Days)
        //            .Include(ads => ads.Description)
        //            .AsNoTracking()
        //            .ToList();

        //    return cityFilter;
        //}

        private List<Advert> filterByBudget(string MonthOrWeek, int budget, List<Advert> originalList, List<Advert> goalList)
        {
            //if (MonthOrWeek != null)
            //{
            //    List<Advert> tempList = new();
            //    if (goalList.Count > 0) { tempList = goalList; }
            //    else { tempList = originalList; }

            //    //FIX NEEDED
            //    int weekBud = 0;
            //    int monthBud = 0;
            //    if (MonthOrWeek == "Month")
            //    {
            //        weekBud = budget / 4;
            //        goalList = tempList.Where(a => a.Budgets.MonthOrWeek == ("Month")
            //            && budget >= a.Budgets.Price
            //            || a.Budgets.MonthOrWeek == ("Week")
            //            && weekBud >= a.Budgets.Price).ToList();
            //    }
            //    if (MonthOrWeek == "Week")
            //    {
            //        monthBud = budget * 4;
            //        goalList = tempList.Where(a => a.Budgets.MonthOrWeek == ("Month")
            //        && monthBud >= a.Budgets.Price
            //        || a.Budgets.MonthOrWeek == ("Week")
            //        && budget >= a.Budgets.Price).ToList();
            //    }
            //}

            return goalList;
        }

        private List<Advert> filterByWorkplace(ICollection<string> workplaceList, List<Advert> originalList, List<Advert> goalList)
        {
            //if (workplaceList.Count > 0)
            //{
            //    List<string> notOther = new List<string>()
            //    {
            //    "Music Studio", "Art Studio", "Photo Studio", "Dance Rehersal Studio",
            //    "Ceramics Studio", "Painting Workshop"
            //    };
            //    List<Advert> tempList = new();
            //    if (goalList.Count > 0) { tempList = goalList; }
            //    else { tempList = originalList; }

            //    foreach (var studio in workplaceList)
            //    {
            //        if (studio != "Other")
            //        {
            //            goalList = tempList.Where(w => w.WorkspaceDescription == studio).ToList();
            //        }
            //        else
            //        {
            //            goalList = tempList.Where(f1 => notOther.All(f2 => f2 != f1.WorkspaceDescription)).ToList();
            //        }
            //    }
            //}
            return goalList;
        }

        //private List<Advert> filterByAmenities(List<bool> checkedAmenities, List<Advert> originalList, List<Advert> goalList)
        //{
        //    TempData["parking"] = checkedAmenities[0];
        //    TempData["airCon"] = checkedAmenities[1];
        //    TempData["kitchen"] = checkedAmenities[2];
        //    TempData["naturalLight"] = checkedAmenities[3];
        //    TempData["aucusticTreatment"] = checkedAmenities[4];
        //    TempData["runningWater"] = checkedAmenities[5];
        //    TempData["storage"] = checkedAmenities[6];
        //    TempData["other"] = checkedAmenities[7];

        //    if (checkedAmenities.Contains(true))
        //    {
        //        List<Advert> tempList = new();

        //        foreach (var ad in originalList)
        //        {
        //            var d = ad.Amenities;
        //            var thisAdsAmenitiesList = d.GetList();
        //            bool hasAtleastOne = false;
        //            for (int i = 0; i < thisAdsAmenitiesList.Count; i++)
        //            {
        //                if (checkedAmenities[i] == true && thisAdsAmenitiesList[i] == true)
        //                {
        //                    hasAtleastOne = true;
        //                }
        //            }
        //            if (hasAtleastOne)
        //            {
        //                tempList.Add(ad);
        //            }
        //            if (checkedAmenities[7] == true && d.Other != null)
        //            {
        //                tempList.Add(ad);
        //            }
        //        }

        //        tempList = tempList.Except(goalList).ToList();
        //        goalList.AddRange(tempList);
        //    }
        //    return goalList;
        //}

        //private List<Advert> filterByDays(List<bool> checkedDays, List<Advert> originalList, List<Advert> goalList)
        //{
        //    TempData["monday"] = checkedDays[0];
        //    TempData["tuesday"] = checkedDays[1];
        //    TempData["wednesday"] = checkedDays[2];
        //    TempData["thursday"] = checkedDays[3];
        //    TempData["friday"] = checkedDays[4];
        //    TempData["saturday"] = checkedDays[5];
        //    TempData["sunday"] = checkedDays[6];

        //    if (checkedDays.Contains(true))
        //    {
        //        List<Advert> tempList = new();

        //        foreach (var ad in originalList)
        //        {
        //            var d = ad.DatesAndTimes.Days;
        //            var thisAdsDaysList = d.GetList();
        //            bool hasAtleastOne = false;
        //            for (int i = 0; i < thisAdsDaysList.Count; i++)
        //            {
        //                if (thisAdsDaysList[i] == true && checkedDays[i] == true)
        //                {
        //                    hasAtleastOne = true;
        //                }
        //            }
        //            if (hasAtleastOne)
        //            {
        //                tempList.Add(ad);
        //            }
        //        }

        //        tempList = tempList.Except(goalList).ToList();
        //        goalList.AddRange(tempList);
        //    }

        //    return goalList;
        //}

        public IActionResult Empty()
        {

            return RedirectToAction("Adverts", "Adverts");
        }
    }
}


