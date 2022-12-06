using Microsoft.AspNetCore.Mvc;

namespace LingonberryStudio.Controllers.Adverts
{
    public class AdvertsController : Controller
    {
        public IActionResult Adverts()
        {
            return View();
        }
    }
}
