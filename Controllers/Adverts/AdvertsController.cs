using LingonberryStudio.Data;
using LingonberryStudio.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Tar;
using System.Linq;
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
			List<Advert> ads = _db.Adverts.ToList();

			List<Amenity> amenities = _db.Amenities.ToList();
			List<Measurement> measuremen = _db.Measurements.ToList();
			List<DatesAndTime> datesAndTimes = _db.DatesAndTimes.ToList();
			List<Day> days = _db.Days.ToList();
			List<Budget> budgets = _db.Budgets.ToList();
			List<Description> description = _db.Descriptions.ToList();

			ViewBag.Total = ads.Count();
			return View(ads);
		}


		//[HttpGet]
		public IActionResult Search(string id, string search)
		{
			if (search == "Offering")
			{
				List<Advert> offeringAds = _db.Adverts.Where(ad => ad.OfferingLooking == "Offering" && ad.City == id).ToList();
				foreach (var ad in offeringAds)
				{
					List<Amenity> amenities = _db.Amenities.Where(a => a.AmenityID == ad.AdvertId).ToList();
					List<Measurement> measuremen = _db.Measurements.Where(a => a.MeasurementID == ad.AdvertId).ToList();
					List<DatesAndTime> datesAndTimes = _db.DatesAndTimes.Where(a => a.DatesAndTimeId == ad.AdvertId).ToList();
					List<Day> days = _db.Days.Where(a => a.DayId == ad.AdvertId).ToList();
					List<Budget> budgets = _db.Budgets.Where(a => a.BudgetId == ad.AdvertId).ToList();
					List<Description> description = _db.Descriptions.Where(a => a.ImageID == ad.AdvertId).ToList();
				}
				return View(offeringAds);
			}
			if (search == "Looking")
			{
				List<Advert> lookingAds = _db.Adverts.Where(ad => ad.OfferingLooking == "Looking" && ad.City == id).ToList();
				foreach (var ad in lookingAds)
				{
					List<Amenity> amenities = _db.Amenities.Where(a => a.AmenityID == ad.AdvertId).ToList();
					List<Measurement> measuremen = _db.Measurements.Where(a => a.MeasurementID == ad.AdvertId).ToList();
					List<DatesAndTime> datesAndTimes = _db.DatesAndTimes.Where(a => a.DatesAndTimeId == ad.AdvertId).ToList();
					List<Day> days = _db.Days.Where(a => a.DayId == ad.AdvertId).ToList();
					List<Budget> budgets = _db.Budgets.Where(a => a.BudgetId == ad.AdvertId).ToList();
					List<Description> description = _db.Descriptions.Where(a => a.ImageID == ad.AdvertId).ToList();
				}
				return View(lookingAds);
			}
			return RedirectToAction("Adverts");
		}


		public IActionResult Form()
		{
			return PartialView("_FormPartial");
		}

		[HttpPost]
		//[ValidateAntiForgeryToken]
		public IActionResult CreateAd(Advert ad)
		{
			var errors = ModelState.Values.SelectMany(v => v.Errors);

			if (ModelState.IsValid)
			{
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
				//_db.Amenities.Add(ad.Amenities);
				//_db.Measurements.Add(ad.Measurements);
				//_db.DatesAndTimes.Add(ad.DatesAndTimes);
				//_db.Days.Add(ad.DatesAndTimes.Days);
				//_db.Budgets.Add(ad.Budgets);
				//_db.Profiles.Add(ad.Profiles);
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
