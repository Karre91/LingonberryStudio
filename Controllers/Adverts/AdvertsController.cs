using LingonberryStudio.Data;
using LingonberryStudio.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
			List<Budget> budget = _db.Budget.ToList();


			return View(ads);
        }

        public IActionResult AdvertSearch(string id)
        {
            List<Advert> ads = _db.Adverts.ToList();
            foreach (var ad in ads){
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
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                _db.Adverts.Add(ad);
                _db.Amenities.Add(ad.Amenities);
                _db.Measurements.Add(ad.Measurements);
                _db.DatesAndTimes.Add(ad.DatesAndTimes);
                _db.Days.Add(ad.DatesAndTimes.Days);
                _db.Budget.Add(ad.Budgets);
                _db.SaveChanges();       
                
            }
            return RedirectToAction("Adverts");
        }
    }
}
