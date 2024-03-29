﻿namespace LingonberryStudio.Controllers.Adverts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LingonberryStudio.Data;
    using LingonberryStudio.Data.Entities;
    using LingonberryStudio.Models;
    using LingonberryStudio.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;

    public class AdvertsController : Controller
    {
        private readonly LingonberryDbContext db;
        private readonly IWebHostEnvironment web;
        private readonly IMemoryCache cache;

        public AdvertsController(LingonberryDbContext db, IWebHostEnvironment web, IMemoryCache memoryCache)
        {
            this.db = db;
            this.web = web;
            this.cache = memoryCache;
        }

        public IActionResult Form()
        {
            return PartialView("_FormPartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAd(AdvertViewMoldel incoming)
        {
            // var errors = ModelState.Values.SelectMany(v => v.Errors);
            var potentialAd = incoming.Advert;
            if (ModelState.IsValid)
            {
                potentialAd.WorkPlace.City = potentialAd.WorkPlace.City.ToUpper();
                potentialAd.StudioType = potentialAd.StudioType.Replace(" ", string.Empty);
                if (potentialAd.WorkPlace.FormFile != null)
                {
                    potentialAd.WorkPlace.ImgUrl = "StudioImages/" + Guid.NewGuid().ToString() + "_" + potentialAd.WorkPlace.FormFile.FileName;
                    var path = Path.Combine(web.WebRootPath, potentialAd.WorkPlace.ImgUrl);
                    potentialAd.WorkPlace.FormFile.CopyToAsync(new FileStream(path, FileMode.Create));
                }
                else
                {
                    potentialAd.WorkPlace.ImgUrl = "StudioImages/handshake.jpg";
                }

                if (potentialAd.WorkPlace.Period == "Week")
                {
                    potentialAd.WorkPlace.Pounds = potentialAd.WorkPlace.Pounds * 4;
                }

                db.Adverts.Add(potentialAd);
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
        public IActionResult Adverts(AdvertViewMoldel viewModel, bool hasFilter, string city, bool offering)
        {
            //string cacheKey = "adverts";
            //List<Advert> cacheList = new();
            //if (!cache.TryGetValue(cacheKey, out List<Advert>? cacheAds))
            //{
            //    // Data not in the cache, retrieve it from the database and add it to the cache
            //    cacheAds = GetAdsInDB();
            //    if (cacheAds != null)
            //    {
            //        cache.Set(cacheKey, cacheList, TimeSpan.FromMinutes(30)); // Cache for 30 minutes
            //    }
            //}
            //else
            //{
            //    cacheList = cacheAds!.ToList();
            //}

            viewModel.MaxBudget = db.Adverts.Max(a => a.WorkPlace.Pounds);
            if (hasFilter)
            {
                if (city != null)
                {
                    viewModel.Filter.City = city;
                    switch (offering)
                    {
                        case true: viewModel.Filter.Offering = true; break;
                        case false: viewModel.Filter.Looking = true; break;
                    }

                    viewModel.AdvertList = Filter(viewModel.Filter);

                    if (viewModel.AdvertList.Count <= 0)
                    {
                        TempData["searchError"] = $"No results with the city \"{city}\"";
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    viewModel.AdvertList = Filter(viewModel.Filter);
                    if (viewModel.AdvertList.Count <= 0)
                    {
                        ViewBag.CityNotFound = $"No results that matches your filter search";
                    }
                }
            }
            else
            {
                if (viewModel.AdvertList.Count <= 0)
                {
                    viewModel.AdvertList = GetAdsInDB();
                }
            }

            ViewBag.Filter = viewModel.Filter;
            ViewBag.Total = viewModel.AdvertList.Count;
            return View(viewModel);
        }

        public List<Advert> Filter(Filter filter)
        {
            List<int> ids = FilterByOfferingLookingAndBudget(filter);
            ids = FilterByStudioType(filter, ids);
            ids = FilterByCity(filter, ids);
            ids = FilterByAmenities(filter, ids);
            ids = FilterByDays(filter, ids);

            return GetAdsInDB(ids, filter.OrderBy);
        }

        private List<int> FilterByOfferingLookingAndBudget(Filter filter)
        {
            if ((!filter.Looking && !filter.Offering && filter.Month) || (filter.Looking && filter.Offering && filter.Month))
            {
                var filteredIdsIf = db.Adverts
                .Where(a => (a.Offering.Equals(true) && a.WorkPlace.Period == null)
                || (a.Offering.Equals(false) && a.WorkPlace.Period == null)
                || (a.Offering.Equals(true) && a.WorkPlace.Period != null && a.WorkPlace.Pounds <= filter.Pounds)
                || (a.Offering.Equals(false) && a.WorkPlace.Period != null && a.WorkPlace.Pounds >= filter.Pounds))
                .Select(a => a.ID)
                .ToList();

                return filteredIdsIf;
            }

            if ((!filter.Looking && !filter.Offering && !filter.Month) || (filter.Looking && filter.Offering && !filter.Month))
            {
                List<int> filteredIdsIf = db.Adverts
                .Where(a => (a.Offering.Equals(true) && a.WorkPlace.Period == null)
                || (a.Offering.Equals(false) && a.WorkPlace.Period == null)
                || (a.Offering.Equals(true) && a.WorkPlace.Period != null)
                || (a.Offering.Equals(false) && a.WorkPlace.Period != null))
                .Select(a => a.ID)
                .ToList();

                return filteredIdsIf;
            }

            if (filter.Offering && filter.Month)
            {
                List<int> filteredIdsIf = db.Adverts
                .Where(a => (a.Offering.Equals(true) && a.WorkPlace.Period == null)
                || (a.Offering.Equals(true) && a.WorkPlace.Period != null && a.WorkPlace.Pounds <= filter.Pounds))
                .Select(a => a.ID)
                .ToList();

                return filteredIdsIf;
            }

            if (filter.Looking && filter.Month)
            {
                List<int> filteredIdsIf = db.Adverts
                .Where(a => (a.Offering.Equals(false) && a.WorkPlace.Period != null && a.WorkPlace.Pounds >= filter.Pounds)
                || (a.Offering.Equals(false) && a.WorkPlace.Period == null))
                .Select(a => a.ID)
                .ToList();

                return filteredIdsIf;
            }

            if ((filter.Offering && !filter.Month) || (filter.Looking && !filter.Month))
            {
                bool isTrue = true;
                if (filter.Looking)
                {
                    isTrue = false;
                }

                List<int> filteredIdsIf = db.Adverts
                .Where(a => (a.Offering.Equals(isTrue) && a.WorkPlace.Period == null)
                || (a.Offering.Equals(isTrue) && a.WorkPlace.Period != null))
                .Select(a => a.ID)
                .ToList();

                return filteredIdsIf;
            }

            var filteredIds = db.Adverts
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
                        "CeramicsStudio", "PaintingStudio",
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
                var filteredIds = db.Adverts
                    .Where(a => ids.Contains(a.ID))
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

        private List<int> FilterByAmenities(Filter filter, List<int> ids)
        {
            if (filter.GetAllAmenityTuple().Any(a => a.Item2.Equals(true)))
            {
                List<int> filteredIds = new();
                foreach (var ad in db.Adverts.Where(a => ids.Contains(a.ID)).Include(a => a.WorkPlace).ThenInclude(a => a.AmenityTypes).Select(a => a.WorkPlace.AmenityTypes).ToList())
                {
                    var thisAdsAmenitiesList = ad.GetAllAmenityTuple().Select(amenity => amenity.Item2).ToList();
                    var filterAmenitiesList = filter.GetAllAmenityTuple().Select(amenity => amenity.Item2).ToList();
                    for (int i = 0; i < thisAdsAmenitiesList.Count; i++)
                    {
                        if (filterAmenitiesList[i] && thisAdsAmenitiesList[i])
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

        private List<int> FilterByDays(Filter filter, List<int> ids)
        {
            if (filter.GetAllDaysTuple().Any(a => a.Item2.Equals(true)))
            {
                List<int> filteredIds = new();
                foreach (var ad in db.Adverts.Where(a => ids.Contains(a.ID)).Select(a => a.WorkPlace.TimeFrames).ToList())
                {
                    var thisAdsDaysList = ad.GetAllDaysTuple().Select(day => day.Item2).ToList();
                    var filterDaysList = filter.GetAllDaysTuple().Select(day => day.Item2).ToList();
                    for (int i = 0; i < thisAdsDaysList.Count; i++)
                    {
                        if (filterDaysList[i] && thisAdsDaysList[i])
                        {
                            filteredIds.Add(ad.DatesAndTimeID);

                            break;
                        }
                    }
                }

                return filteredIds;
            }

            return ids;
        }

        private List<Advert> ExcludeOldAdsIds(List<Advert> allAdsInDB)
        {
            var goalList = allAdsInDB.Except(allAdsInDB.Where(ad => (ad.TimeCreated.Date - DateTime.Now).Days! <= -180)).ToList();
            return goalList;
        }

        private List<Advert> GetAdsInDB(List<int> ids, OrderBy myOrder = OrderBy.DateNewToOld)
        {
            var query = db.Adverts
                .Include(ads => ads.WorkPlace)
                .ThenInclude(ads => ads.AmenityTypes)
                .Include(ads => ads.WorkPlace)
                .ThenInclude(ads => ads.TimeFrames)
                .Where(p => ids.Contains(p.ID));

            switch (myOrder)
            {
                case OrderBy.PriceLowToHigh:
                    query = query.OrderBy(p => p.WorkPlace.Pounds);
                    break;
                case OrderBy.PriceHighToLow:
                    query = query.OrderBy(p => p.WorkPlace.Pounds).Reverse();
                    break;
                case OrderBy.DateNewToOld:
                    query = query.OrderBy(p => p.TimeCreated).Reverse();
                    break;
                case OrderBy.DateOldToNew:
                    query = query.OrderBy(p => p.TimeCreated);
                    break;
            }

            var filteredAdsInDB = query
                .AsNoTracking()
                .ToList();

            return ExcludeOldAdsIds(filteredAdsInDB);
        }

        private List<Advert> GetAdsInDB()
        {
            List<Advert> allAdsInDB = db.Adverts
            .Include(ads => ads.WorkPlace)
            .ThenInclude(ads => ads.AmenityTypes)
            .Include(ads => ads.WorkPlace)
            .ThenInclude(ads => ads.TimeFrames)
            .OrderBy(p => p.TimeCreated).Reverse()
            .AsNoTracking()
            .ToList();

            return ExcludeOldAdsIds(allAdsInDB);
        }
    }
}