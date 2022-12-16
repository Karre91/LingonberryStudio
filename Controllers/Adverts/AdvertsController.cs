using LingonberryStudio.Data;
using LingonberryStudio.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LingonberryStudio.Controllers.Adverts
{
    public class AdvertsController : Controller
    {
        private readonly LingonberryDbContext _db;

        public AdvertsController(LingonberryDbContext db)
        {
            _db = db;
        }

        [HttpGet("Adverts")]
        public IActionResult Adverts()
        {
            List<Advert> ads = _db.Adverts.ToList();
            List<Amenity> amenities = _db.Amenities.ToList();
            List<Measurement> measuremen = _db.Measurements.ToList();
            List<DatesAndTime> datesAndTimes = _db.DatesAndTimes.ToList();
            List<Day> days = _db.Days.ToList();

            return View(ads);
        }
        //[HttpGet]
        public IActionResult AdvertSearch(string id)
        {
            List<Advert> ads = _db.Adverts.ToList();
            foreach (var ad in ads)
            {
                if (id == ad.PostCode)
                {
                    return RedirectToAction("Adverts");
                }
            }
            return RedirectToAction("Error", "Home");
        }

        public IActionResult Form()
        {
            return PartialView("_Form");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult CreateAd(Advert ad)
        {
            //var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                _db.Adverts.Add(ad);
                _db.Amenities.Add(ad.Amenities);
                _db.Measurements.Add(ad.Measurements);
                _db.DatesAndTimes.Add(ad.DatesAndTimes);
                _db.Days.Add(ad.DatesAndTimes.Days);
                _db.SaveChanges();

            }
            return RedirectToAction("Adverts");
        }

        //[HttpGet("Chosen")]
        //public IActionResult ChosenAd(int id)
        //{
        //    if (id == 0)
        //    {
        //        return View();
        //    }
        //    //var venue = _db.Adverts.FirstOrDefault(x => x.AdvertId == id);
        //    var data = _db.Adverts.Where(m => m.AdvertId == id).Select(p => p).ToList();
        //    return PartialView("_ChosenAd", data);
        //}
    }
}
