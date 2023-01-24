namespace LingonberryStudio.Controllers.Adverts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata;
    using System.Security.Cryptography;
    using LingonberryStudio.Data;
    using LingonberryStudio.Data.Entities;
    using LingonberryStudio.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Microsoft.VisualBasic;
    using static System.Net.Mime.MediaTypeNames;

    public class AdvertsController : Controller
    {
        private readonly LingonberryDbContext db;
        private readonly IWebHostEnvironment web;

        public AdvertsController(LingonberryDbContext db, IWebHostEnvironment web)
        {
            this.db = db;
            this.web = web;
        }

        public IActionResult Form()
        {
            return PartialView("_FormPartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAd(AdvertViewMoldel potentialAd)
        {
            // var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                potentialAd.Advert.WorkPlace.City = potentialAd.Advert.WorkPlace.City.ToUpper();

                if (potentialAd.Advert.WorkPlace.FormFile != null)
                {
                    potentialAd.Advert.WorkPlace.ImgUrl = "StudioImages/" + Guid.NewGuid().ToString() + "_" + potentialAd.Advert.WorkPlace.FormFile.FileName;
                    var path = Path.Combine(web.WebRootPath, potentialAd.Advert.WorkPlace.ImgUrl);
                    potentialAd.Advert.WorkPlace.FormFile.CopyToAsync(new FileStream(path, FileMode.Create));
                }
                else
                {
                    // if offering == true osv
                    potentialAd.Advert.WorkPlace.ImgUrl = "StudioImages/handshake.jpg";
                }

                db.Adverts.Add(potentialAd.Advert);
                db.SaveChanges();
                return RedirectToAction("Adverts");
            }

            return PartialView("_FormPartial", potentialAd);
        }

        public new IActionResult Empty()
        {
            return this.RedirectToAction("Adverts", "Adverts");
        }

        [HttpGet]
        public IActionResult Adverts(AdvertViewMoldel viewModel, bool hasFilter, bool search, string city)
        {
            if (city != null)
            {
                viewModel.AdvertList = db.Adverts.Where(ad => ad.Offering == search && ad.WorkPlace.City == city).ToList();
                viewModel.IsFiltered = true;
                viewModel.Filter.City = city;

                if (search)
                {
                    viewModel.Filter.Offering = search;
                }
                else
                {
                    viewModel.Filter.Looking = search;
                }

                return View(viewModel);
            }

            if (hasFilter)
            {
                viewModel.AdvertList = Filter(viewModel.Filter);
            }
            else
            {
                if (viewModel.AdvertList.Count <= 0)
                {
                    viewModel.AdvertList = GetAdsInDB();
                }
            }

            AdvertViewMoldel advertViewModel = new ();
            advertViewModel.AdvertList = GetAdsInDB();

            ViewBag.Total = viewModel.AdvertList.Count;

            return View(viewModel);
        }

        public List<Advert> Filter(Filter filter)
        {
            List<int> ids = FilterByOfferingLooking(filter);
            ids = FilterByStudioType(filter, ids);
            ids = FilterByCity(filter, ids);
            ids = FilterByBudget(filter, ids);
            ids = FilterByAmenities(filter, ids);

            List<Advert> allAdsInDB = db.Adverts
            .Include(ads => ads.WorkPlace)
            .ThenInclude(ads => ads.AmenityTypes)
            .Include(ads => ads.WorkPlace)
            .ThenInclude(ads => ads.TimeFrames)
            .Where(p => ids.Contains(p.ID))
            .AsNoTracking()
            .ToList();

            allAdsInDB = ExcludeOldAds(allAdsInDB);
            return allAdsInDB;
        }

        private static List<Advert> ExcludeOldAds(List<Advert> allAdsInDB)
        {
            var goalList = allAdsInDB.Except(allAdsInDB.Where(ad => (ad.TimeCreated.Date - DateTime.Now).Days! <= -60)).ToList();
            return goalList;
        }

        private List<int> FilterByOfferingLooking(Filter filter)
        {
            var filteredIds = db.Adverts
            .Where(a => a.Offering.Equals(filter.Offering) || a.Offering.Equals(!filter.Looking))
            .Select(a => a.ID)
            .ToList();

            return filteredIds;
        }

        private List<int> FilterByStudioType(Filter filter, List<int> ids)
        {
            if (filter.GetChosenStudioTypes().Any())
            {
                List<int> filteredIds = new();
                if (filter.OtherStudio)
                {
                    List<string> preDecidedStudios = new()
                    {
                        "MusicStudio", "ArtStudio", "PhotoStudio", "DanceRehersalStudio",
                        "CeramicsStudio", "PaintingWorkshop",
                    };

                    filteredIds = db.Adverts
                        .Where(a => ids.Contains(a.ID))
                        .Where(a1 => preDecidedStudios.All(a2 => a2 != a1.StudioType))
                        .Select(a => a.ID)
                        .ToList();
                }

                var filtered = db.Adverts
                .Where(a => ids.Contains(a.ID))
                .Where(a => filter.GetChosenStudioTypes().Contains(a.StudioType))
                .Select(a => a.ID)
                .ToList();

                filteredIds.AddRange(filtered);

                return filteredIds;
            }

            return ids;
        }

        private List<int> FilterByCity(Filter filter, List<int> ids)
        {
            if (filter.City != null)
            {
                var filteredIds = db.Adverts.Where(a => ids.Contains(a.ID)).Include(a => a.WorkPlace)
                   .Where(a => a.WorkPlace.City.ToUpper().Equals(filter.City) || (a.WorkPlace.City != null && filter.City == null))
                   .Select(a => a.ID)
                   .ToList();

                return filteredIds;
            }
            else
            {
                return ids;
            }
        }

        private List<int> FilterByBudget(Filter filter, List<int> ids)
        {
            if (filter.Period != null)
            {
                List<int> filteredIds = db.Adverts.Where(a => ids.Contains(a.ID)).Include(a => a.WorkPlace)
                       .Where(a => a.WorkPlace.Period == null)
                       .Select(a => a.ID)
                       .ToList();

                if (filter.Period == "Month")
                {
                    filter.CalculatedPounds = filter.Pounds / 4;

                    var filteredOnMonth = db.Adverts.Where(a => ids.Contains(a.ID)).Include(a => a.WorkPlace)
                       .Where(a => (a.WorkPlace.Period != null) && (a.WorkPlace.Period.Equals(filter.Period) && a.WorkPlace.Pounds <= filter.Pounds))
                       .Select(a => a.ID)
                       .ToList();
                    filteredIds.AddRange(filteredOnMonth);

                    var filteredOnWeek = db.Adverts.Where(a => ids.Contains(a.ID)).Include(a => a.WorkPlace)
                        .Where(a => a.WorkPlace.Period != null && a.WorkPlace.Period != filter.Period && a.WorkPlace.Pounds <= filter.CalculatedPounds)
                        .Select(a => a.ID)
                        .ToList();

                    filteredIds.AddRange(filteredOnWeek);
                }

                if (filter.Period == "Week")
                {
                    filter.CalculatedPounds = filter.Pounds * 4;

                    var filteredOnWeek = db.Adverts.Where(a => ids.Contains(a.ID)).Include(a => a.WorkPlace)
                       .Where(a => (a.WorkPlace.Period != null) && (a.WorkPlace.Period.Equals(filter.Period) && a.WorkPlace.Pounds <= filter.Pounds))
                       .Select(a => a.ID)
                       .ToList();

                    filteredIds.AddRange(filteredOnWeek);

                    var filteredOnMonth = db.Adverts.Where(a => ids.Contains(a.ID)).Include(a => a.WorkPlace)
                       .Where(a => a.WorkPlace.Period != null && a.WorkPlace.Period != filter.Period && a.WorkPlace.Pounds <= filter.CalculatedPounds)
                       .Select(a => a.ID)
                       .ToList();

                    filteredIds.AddRange(filteredOnMonth);
                }

                return filteredIds;
            }

            return ids;
        }

        private List<int> FilterByAmenities(Filter filter, List<int> ids)
        {
            if (filter.GetAllBool().Contains(true))
            {
                List<int> filteredIds = new();
                foreach (var ad in db.Adverts.Where(a => ids.Contains(a.ID)).Include(a => a.WorkPlace).ThenInclude(a => a.AmenityTypes).Select(a => a.WorkPlace.AmenityTypes).ToList())
                {
                    var thisAdsAmenitiesList = ad.GetAllBool();
                    var fBool = filter.GetAllBool();
                    for (int i = 0; i < thisAdsAmenitiesList.Count; i++)
                    {
                        if (fBool[i] && thisAdsAmenitiesList[i])
                        {
                            filteredIds.Add(ad.AmenityID);

                            break;
                        }
                    }
                }

                return filteredIds;
            }

            return ids;
        }

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

        private List<Advert> GetAdsInDB()
        {
            List<Advert> allAdsInDB = db.Adverts
            .Include(ads => ads.WorkPlace)
            .ThenInclude(ads => ads.AmenityTypes)
            .Include(ads => ads.WorkPlace)
            .ThenInclude(ads => ads.TimeFrames)
            .AsNoTracking()
            .ToList();

            allAdsInDB = ExcludeOldAds(allAdsInDB);
            return allAdsInDB;
        }
    }
}