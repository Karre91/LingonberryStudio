using LingonberryStudio.Data;
using LingonberryStudio.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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


        public IActionResult Form(Advert ad)
        {
            return PartialView("_TestForm", ad);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken] // Attribute to help defend cross-site request forgery attacks.
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
