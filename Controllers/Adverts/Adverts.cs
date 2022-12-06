using Microsoft.AspNetCore.Mvc;

namespace LingonberryStudio.Controllers.Adverts
{
    public class Adverts : Controller
    {
        public IActionResult Advert()
        {
            return View();
        }
    }
}
