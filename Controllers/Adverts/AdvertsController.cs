using LingonberryStudio.Data;
using LingonberryStudio.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
			//IEnumerable<Advert> ads = _db.Adverts;
			return View(/*ads*/);

			//IEnumerable<OrderItem> order = _db.OrderItems;
			//List<Tuple<Advert, Product>> adsAndModal = new List<Tuple<OrderItem, Product>>();

			//foreach (OrderItem item in order)
			//{
			//	Product product = _db.Products.Find(item.ProductId);
			//	Tuple<OrderItem, Product> My_Tuple = new Tuple<OrderItem, Product>(item, product);

			//	orderAndProduct.Add(My_Tuple);
			//}
			//return View(orderAndProduct);
		}

        public IActionResult FormPartial(Advert ad)
        {
            return PartialView("_Formpartialview", ad);
        }

	}
}
