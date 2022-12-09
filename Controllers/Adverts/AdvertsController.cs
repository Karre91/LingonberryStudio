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

		//[HttpGet("Form")]
		public IActionResult FormPartial(Advert ad)
        {
            return PartialView("_Form", ad);
        }

    }
}
