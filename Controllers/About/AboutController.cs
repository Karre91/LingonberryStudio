namespace LingonberryStudio.Controllers.About
{
    using LingonberryStudio.Data;
    using LingonberryStudio.Data.Entities;
    using Microsoft.AspNetCore.Mvc;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public class AboutController : Controller
    {
        private readonly IWebHostEnvironment web;
        private readonly LingonberryDbContext db;

        public AboutController(LingonberryDbContext db, IWebHostEnvironment web)
        {
            this.db = db;
            this.web = web;
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
