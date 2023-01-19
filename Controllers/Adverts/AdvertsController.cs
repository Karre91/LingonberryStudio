namespace LingonberryStudio.Controllers.Adverts
{
    using System;
    using System.Linq;
    using LingonberryStudio.Data;
    using LingonberryStudio.Data.Entities;
    using LingonberryStudio.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public IActionResult Adverts(AdvertViewMoldel viewModel)
        {
            AdvertViewMoldel advertViewModel = new ();
            advertViewModel.AdvertList = GetAdsInDB();

            var test = Filter(viewModel);
            Console.WriteLine(test);
            ViewBag.Total = advertViewModel.AdvertList.Count;

            return View(advertViewModel);
        }

        public List<Advert> Filter(AdvertViewMoldel viewModel)
        {
            if (viewModel.Filter.City != null)
            {
                viewModel.Filter.City = viewModel.Filter.City.ToUpper();
            }

            if (viewModel.Filter.Period != null && viewModel.Filter.Period == "Month")
            {
                viewModel.Filter.CalculatedPounds = viewModel.Filter.Pounds / 4;
            }
            else if (viewModel.Filter.Period != null && viewModel.Filter.Period == "Week")
            {
                viewModel.Filter.CalculatedPounds = viewModel.Filter.Pounds * 4;
            }

            // var checkedPreDecidedStudios = viewModel.Filter.GetChosenStudioTypes();

            //    List<string> preDecidedStudios = new ();
            //    if (viewModel?.Filter?.OtherStudio == true)
            //    {
            //        preDecidedStudios.AddRange(new List<string>
            //        {
            //            "MusicStudio", "ArtStudio", "PhotoStudio", "DanceRehersalStudio",
            //            "CeramicsStudio", "PaintingWorkshop",
            //        });
            //    }

            var filtered = db.Adverts
                .Include(a => a.WorkPlace)
                .ThenInclude(ads => ads.TimeFrames)
                .Include(ads => ads.WorkPlace)
                .ThenInclude(ads => ads.AmenityTypes)
                .Where(a => a.WorkPlaceID.Equals(a.ID) && a.WorkPlace.AmenityID.Equals(a.ID))

                .Where(a => a.Offering.Equals(viewModel.Filter.Offering) || a.Offering.Equals(!viewModel.Filter.Looking))
                .Where(a => a.WorkPlace.City.Equals(viewModel.Filter.City) || (a.WorkPlace.City != null && viewModel.Filter.City == null))

                .Where(a =>
                (a.WorkPlace.Period == null && viewModel.Filter.Period == null)
                || (a.WorkPlace.Period != null && viewModel.Filter.Period == null)
                || (a.WorkPlace.Period == null && a.WorkPlace.Period!.Equals(viewModel.Filter.Period))
                || (a.WorkPlace.Period != null && a.WorkPlace.Period.Equals(viewModel.Filter.Period) && a.WorkPlace.Currency <= viewModel.Filter.Pounds
                && a.WorkPlace.Period != null && a.WorkPlace.Period!.Equals(viewModel.Filter.Period) && a.WorkPlace.Currency <= viewModel.Filter.CalculatedPounds)
                || (a.WorkPlace.Period != null && a.WorkPlace.Period.Equals(viewModel.Filter.Period) && a.WorkPlace.Currency <= viewModel.Filter.Pounds)
                || (a.WorkPlace.Period != null && a.WorkPlace.Period!.Equals(viewModel.Filter.Period) && a.WorkPlace.Currency <= viewModel.Filter.CalculatedPounds))
                .AsNoTracking()
                .ToList();

            // .Where(ad => checkedPreDecidedStudios.Contains(ad.StudioType))

            return filtered;

            //            // => (a.Offering.Equals(viewModel.Filter.Offering) || (a.Offering.Equals(!viewModel.Filter.Looking)
            //            // || (a.Offering.Equals(viewModel.Filter.Offering && a.Offering.Equals(!viewModel.Filter.Looking)

            //(a.WorkPlace.Period != null && a.WorkPlace.Period.Equals(viewModel.Filter.Period) && a.WorkPlace.Currency <= viewModel.Filter.Pounds
            //    && a.WorkPlace.Period != null && a.WorkPlace.Period!.Equals(viewModel.Filter.Period) && a.WorkPlace.Currency <= viewModel.Filter.CalculatedPounds)
            //    ||
        }

        private List<Advert> FilterByBudget(Filter filter)
        {
            if (filter.Period != null)
            {
                if (filter.Period == "Month")
                {
                    filter.CalculatedPounds = filter.Pounds / 4;
                    var goalList = db.Adverts.Where(a => a.WorkPlace.Period != null && a.WorkPlace.Period.Equals(filter.Period) && a.WorkPlace.Currency <= filter.Pounds).ToList();
                    Console.WriteLine(goalList);
                }
                else
                {
                    filter.CalculatedPounds = filter.Pounds * 4;
                    var goalList = db.Adverts.Where(a => a.WorkPlace.Period != null && a.WorkPlace.Period.Equals(filter.Period) && a.WorkPlace.Currency <= filter.Pounds).ToList();
                    Console.WriteLine(goalList);
                }
            }

            return new List<Advert>();
        }

        private List<Advert> ExcludeOldAds(List<Advert> allAdsInDB)
        {
            var goalList = allAdsInDB.Except(allAdsInDB.Where(ad => (ad.TimeCreated.Date - DateTime.Now).Days! <= -60)).ToList();
            return goalList;
        }

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

        //[HttpGet("AdvertSearch")]
        //public IActionResult Search(string city, bool search)
        //{
        //    List<Advert> adverts = new ();

        //    if (city == null)
        //    {
        //        adverts = db.Adverts.Where(ad => ad.Offering == search).ToList();
        //    }
        //    else
        //    {
        //        adverts = db.Adverts.Where(ad => ad.Offering == search && ad.WorkPlace.City == city).ToList();
        //    }

        //    return View(adverts);
        //}
    }
}