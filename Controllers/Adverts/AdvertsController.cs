namespace LingonberryStudio.Controllers.Adverts
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using LingonberryStudio.Data;
    using LingonberryStudio.Data.Entities;
    using LingonberryStudio.Data.Repositories;
    using LingonberryStudio.Models;
    using LingonberryStudio.ViewModels;
    using Microsoft.AspNetCore.Http.Extensions;
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
            StringBuilder query = new StringBuilder("SELECT * FROM Adverts WHERE ");
            StringBuilder queryBuilderPredecidedStudio = new StringBuilder();
            StringBuilder queryBuilderOtherStudio = new StringBuilder();

            if (filter.GetChosenStudioTypes().Any() || filter.OtherStudio)
            {
                if (filter.GetChosenStudioTypes().Any())
                {
                    List<string> chosenStudioTypes = filter.GetChosenStudioTypes();
                    queryBuilderPredecidedStudio.Append("StudioType IN ('");
                    queryBuilderPredecidedStudio.Append(string.Join("', '", chosenStudioTypes));
                    queryBuilderPredecidedStudio.Append("') AND ");
                    CheckAllOtherFilters(queryBuilderPredecidedStudio);
                }

                if (filter.OtherStudio)
                {
                    List<string> preDecidedStudios = new List<string>
                    {
                        "MusicStudio", "ArtStudio", "PhotoStudio", "DanceRehersalStudio",
                        "CeramicsStudio", "PaintingWorkshop",
                    };

                    StringBuilder queryBuilderOtherStudioT = new StringBuilder();
                    queryBuilderOtherStudioT.Append("StudioType NOT IN ('");
                    queryBuilderOtherStudioT.Append(string.Join("', '", preDecidedStudios));
                    queryBuilderOtherStudioT.Append("') AND ");
                    CheckAllOtherFilters(queryBuilderOtherStudioT);

                    if (queryBuilderPredecidedStudio.ToString().Any())
                    {
                        queryBuilderOtherStudio.Append(" OR (" + queryBuilderOtherStudioT + ")");
                    }
                }
            }
            else
            {
                CheckAllOtherFilters(query);
            }

            string queryString = query.Append(queryBuilderPredecidedStudio.Append(queryBuilderOtherStudio)).ToString();

            Debug.WriteLine(queryString);
            return advertRepository.GetAllPreviewAdsInDB(queryString);

            void CheckAllOtherFilters(StringBuilder queryBuilder)
            {
                //CITY
                if (!string.IsNullOrEmpty(filter.City))
                {
                    City(queryBuilder);
                }

                //BUDGET
                if (filter.Month)
                {
                    Budget(queryBuilder);
                }

                //AMENITIES
                if (filter.GetAllAmenityTuple().Any(a => a.Item2.Equals(true)))
                {
                    Amenities(queryBuilder);
                }

                //DAYS
                if (filter.GetAllDaysTuple().Any(a => a.Item2.Equals(true)))
                {
                    Days(queryBuilder);
                }

                //OFFERING
                Offering(queryBuilder);

                void Offering(StringBuilder queryBuilder)
                {
                    queryBuilder.Append($"Offering = '{filter.Offering}' AND ");
                }

                void City(StringBuilder queryBuilder)
                {
                    queryBuilder.Append($"City = '{filter.City}' AND ");
                }

                void Budget(StringBuilder queryBuilder)
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

                void Amenities(StringBuilder queryBuilder)
                {
                    List<Tuple<string, bool>> amenity = filter.GetAllAmenityTuple();
                    queryBuilder.Append("(");
                    for (int i = 0; i < amenity.Count; i++)
                    {
                        var (amen, include) = amenity[i];

                        if (include)
                        {
                            if (amen == "Other")
                            {
                                queryBuilder.Append($"{amen} != NULL OR ");
                            }
                            else
                            {
                                queryBuilder.Append($"{amen} = 1 OR ");
                            }

                        }
                    }

                    // Remove the trailing " OR "
                    queryBuilder.Remove(queryBuilder.Length - 4, 4);
                    queryBuilder.Append(") AND ");
                }

                void Days(StringBuilder queryBuilder)
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
            }
        }

        // GET endpoint to retrieve the full Advert based on the ID
        [HttpGet]
        [Route("api/advert/{id}")]
        public IActionResult GetAdvertById(int id)
        {
            var advert = advertRepository.RetreveAdvertByID(id);
            if (advert == null)
            {
                return NotFound();
            }

            return View("_AdvertDetail", advert);
        }

        public IActionResult GetPopupContent(int adId)
        {
            var advert = advertRepository.RetreveAdvertByID(adId);
            if (advert == null)
            {
                return NotFound();
            }

            return PartialView("_AdvertDetail", advert);
        }

        public IActionResult GetFilterContent()
        {
            AdvertViewMoldel test = new();

            return PartialView("_FilterPartial", test);
        }
    }
}