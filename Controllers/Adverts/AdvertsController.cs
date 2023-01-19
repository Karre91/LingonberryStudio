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

            this.ViewBag.Total = advertViewModel.AdvertList.Count;
            return View(advertViewModel);
        }

        public List<Advert> Filter(AdvertViewMoldel viewModel)
        {
            if (viewModel.Filter.City != null)
            {
                viewModel.Filter.City = viewModel.Filter.City.ToUpper();
            }

            //    //int weekBud = 0, monthBud = 0;
            //    //if (viewModel.Filter.Period == "Month")
            //    //{
            //    //    weekBud = viewModel.Filter.Currency / 4;
            //    //    monthBud = viewModel.Filter.Currency;
            //    //}

            //    //if (viewModel?.Filter?.Period == "Week")
            //    //{
            //    //    monthBud = viewModel.Filter.Currency * 4;
            //    //    weekBud = viewModel.Filter.Currency;
            //    //}

            //    //var checkedPreDecidedStudios = viewModel?.Filter?.GetChosenStudioTypes();

            //    List<string> preDecidedStudios = new ();
            //    if (viewModel?.Filter?.OtherStudio == true)
            //    {
            //        preDecidedStudios.AddRange(new List<string>
            //        {
            //            "MusicStudio", "ArtStudio", "PhotoStudio", "DanceRehersalStudio",
            //            "CeramicsStudio", "PaintingWorkshop",
            //        });
            //    }

            //    var filtered = db.Adverts
            //            .Where(a => a.Offering.Equals(viewModel.Filter.Advert.Offering))

            //            // => (a.Offering.Equals(viewModel.Filter.Offering) || (a.Offering.Equals(!viewModel.Filter.Looking)
            //            // || (a.Offering.Equals(viewModel.Filter.Offering && a.Offering.Equals(!viewModel.Filter.Looking)
            //            .Include(ads => ads.WorkPlace)
            //            .ThenInclude(ads => ads.TimeFrames)
            //            .Include(ads => ads.WorkPlace)
            //            .ThenInclude(ads => ads.AmenityTypes)

            //            // .Where(adverts
            //            // => adverts.WorkPlace.City == viewModel.Filter.City
            //            // || viewModel.Filter.City == null)

            //            // .Where(ad => (ad.WorkPlace.Period != null && ad.WorkPlace.Period == "Month" && ad.WorkPlace.Currency <= monthBud) || (ad.WorkPlace.Period != null && ad.WorkPlace.Period == "Week" && ad.WorkPlace.Currency <= weekBud)
            //            // || viewModel.Filter.Period == null)

            //            // .Where(ad => checkedPreDecidedStudios.Contains(ad.StudioType))
            //            .AsNoTracking()
            //            .ToList();

            return new List<Advert>();
        }

        [HttpGet("AdvertSearch")]
        public IActionResult Search(string city, bool search, List<Advert> adverts)
        {
            if (city == null)
            {
                adverts = db.Adverts.Where(ad => ad.Offering == search).ToList();
            }
            else
            {
                adverts = db.Adverts.Where(ad => ad.Offering == search && ad.WorkPlace.City == city).ToList();
            }

            return View(adverts);
        }

        private static List<Advert> ExcludeOldAds(List<Advert> allAdsInDB)
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
    }
}