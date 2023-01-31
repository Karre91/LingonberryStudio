namespace LingonberryStudio.Controllers.Adverts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata;
    using System.Security.Cryptography;
    using LingonberryStudio.Data;
    using LingonberryStudio.Data.Entities;
    using LingonberryStudio.Models;
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
        public IActionResult CreateAd(AdvertViewMoldel incoming)
        {
            // var errors = ModelState.Values.SelectMany(v => v.Errors);
            var potentialAd = incoming.Advert;
            if (ModelState.IsValid)
            {
                potentialAd.WorkPlace.City = potentialAd.WorkPlace.City.ToUpper();

                if (potentialAd.WorkPlace.FormFile != null)
                {
                    potentialAd.WorkPlace.ImgUrl = "StudioImages/" + Guid.NewGuid().ToString() + ".jpg";
                    var path = Path.Combine(web.WebRootPath, potentialAd.WorkPlace.ImgUrl);
                    potentialAd.WorkPlace.FormFile.CopyToAsync(new FileStream(path, FileMode.Create));
                }
                else
                {
                    if (potentialAd.Offering)
                    {
                        potentialAd.WorkPlace.ImgUrl = "StudioImages/handshakeOffering.jpg";
                    }
                    else
                    {
                        potentialAd.WorkPlace.ImgUrl = "StudioImages/handshakeLooking.jpg";
                    }
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
            if (city != null)
            {
                viewModel.Filter.City = city;
                switch (offering)
                {
                    case true: viewModel.Filter.Offering = offering; break;
                    case false: viewModel.Filter.Looking = offering; break;
                }

                viewModel.AdvertList = Filter(viewModel.Filter);

                if (viewModel.AdvertList.Count <= 0)
                {
                    TempData["searchError"] = $"No results with the city \"{city}\"";
                    return RedirectToAction("Index", "Home");
                }
            }

            if (hasFilter)
            {
                viewModel.AdvertList = Filter(viewModel.Filter);
                if (viewModel.AdvertList.Count <= 0)
                {
                    ViewBag.CityNotFound = $"No results with the city \"{viewModel.Filter.City}\"";
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
            List<int> ids = FilterByOfferingLooking(filter);
            ids = FilterByStudioType(filter, ids);
            ids = FilterByCity(filter, ids);
            ids = FilterByBudget(filter, ids);
            ids = FilterByAmenities(filter, ids);
            ids = FilterByDays(filter, ids);

            return GetAdsInDB(ids, filter.OrderByTest);
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
            switch (filter.Period)
            {
                case "Month":
                    filter.CalculatedPounds = filter.Pounds / 4;
                    break;
                case "Week":
                    filter.CalculatedPounds = filter.Pounds * 4;
                    break;
                default: return ids;
            }

            List<int> filteredIds = db.Adverts.Where(a => ids.Contains(a.ID)).Include(a => a.WorkPlace)
                   .Where(a => a.WorkPlace.Period == null)
                   .Select(a => a.ID)
                   .ToList();

            var filteredOnMonth = db.Adverts.Where(a => ids.Contains(a.ID)).Include(a => a.WorkPlace)
               .Where(a => (a.WorkPlace.Period != null) && (a.WorkPlace.Period.Equals(filter.Period) && a.WorkPlace.Pounds <= filter.Pounds))
               .Select(a => a.ID)
               .ToList();

            var filteredOnWeek = db.Adverts.Where(a => ids.Contains(a.ID)).Include(a => a.WorkPlace)
                .Where(a => a.WorkPlace.Period != null && a.WorkPlace.Period != filter.Period && a.WorkPlace.Pounds <= filter.CalculatedPounds)
                .Select(a => a.ID)
                .ToList();

            filteredIds.AddRange(filteredOnMonth);

            filteredIds.AddRange(filteredOnWeek);

            return filteredIds;
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
                foreach (var ad in db.Adverts.Where(a => ids.Contains(a.ID)).Include(a => a.WorkPlace).ThenInclude(a => a.TimeFrames).Select(a => a.WorkPlace.TimeFrames).ToList())
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

        private List<Advert> ExcludeOldAds(List<Advert> allAdsInDB)
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

            var allAdsInDB = query
                .AsNoTracking()
                .ToList();

            allAdsInDB = ExcludeOldAds(allAdsInDB);
            return allAdsInDB;
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

            allAdsInDB = ExcludeOldAds(allAdsInDB);
            return allAdsInDB;
        }
    }
}