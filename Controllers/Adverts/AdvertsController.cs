using LingonberryStudio.Data;
using LingonberryStudio.Data.Entities;
using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<Ad> ads = _db.Ads;
            return View(ads);
        }
    }
}
