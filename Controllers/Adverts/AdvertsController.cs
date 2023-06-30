namespace LingonberryStudio.Controllers.Adverts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using LingonberryStudio.Data;
    using LingonberryStudio.Data.Entities;
    using LingonberryStudio.Data.Repositories;
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
        private readonly AdvertRepository advertRepository;

        public AdvertsController(LingonberryDbContext db, IWebHostEnvironment web, IMemoryCache memoryCache)
        {
            this.db = db;
            this.web = web;
            this.cache = memoryCache;
            this.advertRepository = new AdvertRepository(db);
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
                //potentialAd.WorkPlace.City = potentialAd.WorkPlace.City.ToUpper();
                //potentialAd.StudioType = potentialAd.StudioType.Replace(" ", string.Empty);
                //if (potentialAd.WorkPlace.FormFile != null)
                //{
                //    potentialAd.WorkPlace.ImgUrl = "StudioImages/" + Guid.NewGuid().ToString() + "_" + potentialAd.WorkPlace.FormFile.FileName;
                //    var path = Path.Combine(web.WebRootPath, potentialAd.WorkPlace.ImgUrl);
                //    potentialAd.WorkPlace.FormFile.CopyToAsync(new FileStream(path, FileMode.Create));
                //}
                //else
                //{
                //    potentialAd.WorkPlace.ImgUrl = "StudioImages/handshake.jpg";
                //}

                //if (potentialAd.WorkPlace.Period == "Week")
                //{
                //    potentialAd.WorkPlace.Pounds = potentialAd.WorkPlace.Pounds * 4;
                //}

                potentialAd.City = potentialAd.City.ToUpper();
                potentialAd.StudioType = potentialAd.StudioType.Replace(" ", string.Empty);
                if (potentialAd.FormFile != null)
                {
                    potentialAd.ImgUrl = "StudioImages/" + Guid.NewGuid().ToString() + "_" + potentialAd.FormFile.FileName;
                    var path = Path.Combine(web.WebRootPath, potentialAd.ImgUrl);
                    potentialAd.FormFile.CopyToAsync(new FileStream(path, FileMode.Create));
                }
                else
                {
                    potentialAd.ImgUrl = "StudioImages/handshake.jpg";
                }

                if (potentialAd.Period == "Week")
                {
                    potentialAd.Pounds = potentialAd.Pounds * 4;
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

            viewModel.MaxBudget = db.Adverts.Max(a => a.Pounds);
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

                    viewModel.PreviewAdvertList = BuildQueryFromFilter(viewModel.Filter);

                    if (viewModel.PreviewAdvertList.Count <= 0)
                    {
                        TempData["searchError"] = $"No results with the city \"{city}\"";
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    viewModel.PreviewAdvertList = BuildQueryFromFilter(viewModel.Filter);
                    if (viewModel.PreviewAdvertList.Count <= 0)
                    {
                        ViewBag.CityNotFound = $"No results that matches your filter search";
                    }
                }
            }
            else
            {
                viewModel.PreviewAdvertList = advertRepository.GetAllPreviewAdsInDB();
                ViewBag.Total = viewModel.PreviewAdvertList.Count;
                return View(viewModel);
            }

            ViewBag.Filter = viewModel.Filter;
            ViewBag.Total = viewModel.PreviewAdvertList.Count;
            return View(viewModel);
        }

        public List<PreviewAdvert> BuildQueryFromFilter(Filter filter)
        {
            //Build the QUERY
            StringBuilder queryBuilder = new StringBuilder("SELECT * FROM Adverts WHERE ");

            //OFFERING
            if (filter.Offering)
            {
                queryBuilder.Append("Offering = 1 AND ");
            }
            else
            {
                queryBuilder.Append("Offering = 0 AND ");
            }

            //BUDGET
            if (filter.Pounds > 0)
            {
                if (filter.Offering)
                {
                    queryBuilder.Append($"Pounds < '{filter.Pounds}' AND ");
                }
                else
                {
                    queryBuilder.Append($"Pounds > '{filter.Pounds}' AND ");
                }
            }

            //CITY
            if (!string.IsNullOrEmpty(filter.City))
            {
                queryBuilder.Append($"City = '{filter.City}' AND ");
            }

            //STUDIOTYPE
            if (filter.GetChosenStudioTypes().Any())
            {
                List<string> chosenStudioTypes = filter.GetChosenStudioTypes();

                if (filter.OtherStudio)
                {
                    List<string> preDecidedStudios = new List<string>
            {
                "MusicStudio", "ArtStudio", "PhotoStudio", "DanceRehersalStudio",
                "CeramicsStudio", "PaintingWorkshop",
            };

                    queryBuilder.Append("StudioType NOT IN ('");
                    queryBuilder.Append(string.Join("', '", preDecidedStudios));
                    queryBuilder.Append("')) AND ");
                }

                queryBuilder.Append("StudioType IN ('");
                queryBuilder.Append(string.Join("', '", chosenStudioTypes));
                queryBuilder.Append("') AND ");

            }

            //AMENITIES
            if (filter.GetAllAmenityTuple().Any(a => a.Item2.Equals(true)))
            {
                List<Tuple<string, bool>> amenity = filter.GetAllAmenityTuple();
                queryBuilder.Append("(");
                for (int i = 0; i < amenity.Count; i++)
                {
                    var (amen, include) = amenity[i];

                    if (include)
                    {
                        queryBuilder.Append($"{amen} = 1 OR ");
                    }
                }

                // Remove the trailing " OR "
                queryBuilder.Remove(queryBuilder.Length - 4, 4);

                queryBuilder.Append(") AND ");
            }

            //DAYS
            if (filter.GetAllDaysTuple().Any(a => a.Item2.Equals(true)))
            {
                List<Tuple<string, bool>> days = filter.GetAllDaysTuple();

                queryBuilder.Append("(");

                for (int i = 0; i < days.Count; i++)
                {
                    var (day, include) = days[i];

                    if (include)
                    {
                        queryBuilder.Append($"{day} = 1 OR ");
                    }
                }

                // Remove the trailing " OR "
                queryBuilder.Remove(queryBuilder.Length - 4, 4);

                queryBuilder.Append(") AND ");
            }

            // Remove the trailing "AND " if it exists
            if (queryBuilder.ToString().EndsWith("AND "))
            {
                queryBuilder.Length -= 4;
            }

            //string queryString = queryBuilder.ToString();

            return advertRepository.GetAllPreviewAdsInDB(/*queryString*/);
        }

        private List<int> FilterByOfferingLookingAndBudget(Filter filter)
        {
            if ((!filter.Looking && !filter.Offering && filter.Month) || (filter.Looking && filter.Offering && filter.Month))
            {
                var filteredIdsIf = db.Adverts
                .Where(a => (a.Offering.Equals(true) && a.Period == null)
                || (a.Offering.Equals(false) && a.Period == null)
                || (a.Offering.Equals(true) && a.Period != null && a.Pounds <= filter.Pounds)
                || (a.Offering.Equals(false) && a.Period != null && a.Pounds >= filter.Pounds))
                .Select(a => a.ID)
                .ToList();

                return filteredIdsIf;
            }

            if ((!filter.Looking && !filter.Offering && !filter.Month) || (filter.Looking && filter.Offering && !filter.Month))
            {
                List<int> filteredIdsIf = db.Adverts
                .Where(a => (a.Offering.Equals(true) && a.Period == null)
                || (a.Offering.Equals(false) && a.Period == null)
                || (a.Offering.Equals(true) && a.Period != null)
                || (a.Offering.Equals(false) && a.Period != null))
                .Select(a => a.ID)
                .ToList();

                return filteredIdsIf;
            }

            if (filter.Offering && filter.Month)
            {
                List<int> filteredIdsIf = db.Adverts
                .Where(a => (a.Offering.Equals(true) && a.Period == null)
                || (a.Offering.Equals(true) && a.Period != null && a.Pounds <= filter.Pounds))
                .Select(a => a.ID)
                .ToList();

                return filteredIdsIf;
            }

            if (filter.Looking && filter.Month)
            {
                List<int> filteredIdsIf = db.Adverts
                .Where(a => (a.Offering.Equals(false) && a.Period != null && a.Pounds >= filter.Pounds)
                || (a.Offering.Equals(false) && a.Period == null))
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
                .Where(a => (a.Offering.Equals(isTrue) && a.Period == null)
                || (a.Offering.Equals(isTrue) && a.Period != null))
                .Select(a => a.ID)
                .ToList();

                return filteredIdsIf;
            }

            var filteredIds = db.Adverts
                .Select(a => a.ID)
                .ToList();

            return filteredIds;
        }

        private List<Advert> ExcludeOldAdsIds(List<Advert> allAdsInDB)
        {
            var goalList = allAdsInDB.Except(allAdsInDB.Where(ad => (ad.TimeCreated.Date - DateTime.Now).Days! <= -180)).ToList();
            return goalList;
        }

        //private List<Advert> GetAdsInDB(List<int> ids, OrderBy myOrder = OrderBy.DateNewToOld)
        //{
        //    var query = db.Adverts

        //        .Where(p => ids.Contains(p.ID));

        //    switch (myOrder)
        //    {
        //        case OrderBy.PriceLowToHigh:
        //            query = query.OrderBy(p => p.Pounds);
        //            break;
        //        case OrderBy.PriceHighToLow:
        //            query = query.OrderBy(p => p.Pounds).Reverse();
        //            break;
        //        case OrderBy.DateNewToOld:
        //            query = query.OrderBy(p => p.TimeCreated).Reverse();
        //            break;
        //        case OrderBy.DateOldToNew:
        //            query = query.OrderBy(p => p.TimeCreated);
        //            break;
        //    }

        //    var filteredAdsInDB = query
        //        .AsNoTracking()
        //        .ToList();

        //    return ExcludeOldAdsIds(filteredAdsInDB);
        //}

        private List<Advert> GetAdsInDB()
        {
            List<Advert> allAdsInDB = db.Adverts
            .OrderBy(p => p.TimeCreated).Reverse()
            .AsNoTracking()
            .ToList();

            return allAdsInDB /*ExcludeOldAdsIds(allAdsInDB)*/;
        }
    }
}