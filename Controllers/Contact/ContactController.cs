using Microsoft.AspNetCore.Mvc;

namespace LingonberryStudio.Controllers.Contact
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
    }
}
