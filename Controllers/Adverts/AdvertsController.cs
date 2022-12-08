using LingonberryStudio.Data;
using LingonberryStudio.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LingonberryStudio.Controllers.Adverts
{
    public class AdvertsController : Controller
    {
        private readonly LingonberryDbContext _db;


        public AdvertsController(LingonberryDbContext? db)
        {
            _db = db;
        }

        public IActionResult Adverts()
        {

			

			return View();
		}

        public IActionResult FormPartial(FormModel formModel)
        {
            return PartialView("_Formpartialview", formModel);
        }

	}
}
