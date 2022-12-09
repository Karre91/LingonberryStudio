using LingonberryStudio.Data;
using LingonberryStudio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LingonberryStudio.Controllers.Adverts
{
    public class AdvertsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdvertsController(ApplicationDbContext db)
        {
            _db = db;
        }

		public IActionResult Adverts()
		{
			return View();	
		}

		//[HttpPost("Create")]
		//[ValidateAntiForgeryToken] // Attribute to help defend cross-site request forgery attacks.
		//public IActionResult Partial(FormModel formModel) //server side validation
		//{
		//	if (ModelState.IsValid) // Checking if the beach location that's created is valid
		//	{
		//		_db.AdvertsDb.Add(formModel);
		//		_db.SaveChanges(); // saving the beach location to the database
		//		return RedirectToAction("Index");
		//	}
		//	return View(formModel);

		//}


		//public IActionResult FormPartial(FormModel formModel)
		//{
		//    return PartialView("_Formpartialview", formModel)

		//}


	}
}
