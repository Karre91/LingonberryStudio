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
            return View(ads);
        }

        public IActionResult AdvertSearch(string id)
        {
            List<Advert> ads = _db.Adverts.ToList();
            foreach (var ad in ads){
                if (id == ad.Name)
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
            if (ModelState.IsValid)
            {
                _db.Adverts.Add(ad);
                _db.SaveChanges();                 
            }
            return RedirectToAction("Adverts");
        }
    }
}
