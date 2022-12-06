using Microsoft.AspNetCore.Mvc;

namespace LingonberryStudio.Controllers.About
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
