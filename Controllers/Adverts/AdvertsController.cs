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

        public IActionResult FormPartial(FormModel formModel)
        {
            return PartialView("_Formpartialview", formModel);
        }

	}
}
