using LingonberryStudio.Data;
using LingonberryStudio.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Tar;
using System.Linq;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LingonberryStudio.Controllers.Adverts
{
	public class AdvertsController : Controller
	{
		private readonly LingonberryDbContext _db;
		public readonly IWebHostEnvironment _Web;

		public AdvertsController(LingonberryDbContext db, IWebHostEnvironment web)
		{
			_db = db;
			_Web = web;
		}

		[HttpGet("Adverts")]
		public IActionResult Adverts()
		{
			var allAdverts = _db.Adverts

					.Include(ads => ads.Measurements)
					.Include(ads => ads.Amenities)
					.Include(ads => ads.Budgets)
					.Include(ads => ads.DatesAndTimes)
					.Include(ads => ads.DatesAndTimes.Days)
					.Include(ads => ads.Description)
					.ToList();

			foreach (var ad in allAdverts)
			{
				if ((ad.TimeCreated.Date - DateTime.Now).Days! <= -60)
				{
					var validAdverts = _db.Adverts

					.Include(maja => maja.Amenities)
					.Include(maja => maja.Budgets)
					.Include(maja => maja.DatesAndTimes)
					.Include(maja => maja.DatesAndTimes.Days)
					.Include(maja => maja.Description)
					.ToList();

					return View(validAdverts);
				}
			}
			allAdverts.Clear();
			return View(allAdverts);
		}

		[HttpGet("AdvertSearch")]
		public IActionResult Search(string city, string search)
		{
			var adverts = new List<Advert>();
			if (city == null)
			{
				adverts = _db.Adverts
					.Where(ad => ad.OfferingLooking == search)
					.Include(ads => ads.Measurements)
					.Include(ads => ads.Amenities)
					.Include(ads => ads.Budgets)
					.Include(ads => ads.DatesAndTimes)
					.Include(ads => ads.DatesAndTimes.Days)
					.Include(ads => ads.Description)
					.ToList();
			}
			else
			{
				adverts = _db.Adverts
					.Where(ad => ad.OfferingLooking == search && ad.City == city)
					.Include(ads => ads.Measurements)
					.Include(ads => ads.Amenities)
					.Include(ads => ads.Budgets)
					.Include(ads => ads.DatesAndTimes)
					.Include(ads => ads.DatesAndTimes.Days)
					.Include(ads => ads.Description)
					.ToList();
			}
			return View(adverts);
		}


		public IActionResult Form()
		{
			return PartialView("_FormPartial");
		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public IActionResult CreateAd(Advert ad)
		{
			//var errors = ModelState.Values.SelectMany(v => v.Errors);

			if (ModelState.IsValid)
			{

				ad.City = ad.City.ToUpper();


				if (ad.Description.formFile != null)
				{
					ad.Description.ImgUrl = "StudioImages/" + Guid.NewGuid().ToString() + "_" + ad.Description.formFile.FileName;
					var path = Path.Combine(_Web.WebRootPath, ad.Description.ImgUrl);
					ad.Description.formFile.CopyToAsync(new FileStream(path, FileMode.Create));
				}
				else
				{
					ad.Description.ImgUrl = "StudioImages/Test.jpg";
				}

				_db.Adverts.Add(ad);
				_db.SaveChanges();
			}
			return RedirectToAction("Adverts");
		}
	}
}
