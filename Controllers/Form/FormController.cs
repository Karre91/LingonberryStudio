using Microsoft.AspNetCore.Mvc;

namespace LingonberryStudio.Controllers.Form
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
