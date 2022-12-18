using LingonberryStudio.Data;
using LingonberryStudio.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LingonberryStudio.Controllers.About
{
    public class AboutController : Controller
    {
        private readonly LingonberryDbContext _db;
        public readonly IWebHostEnvironment _Web;

        public AboutController(LingonberryDbContext db, IWebHostEnvironment web)
        {
            _db = db;
            _Web = web;
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        [Route("AddPerson")]
        public async Task<IActionResult> AddPerson(ProfileViewModel profileViewModel)
        {
            if (ModelState.IsValid)
            {
                profileViewModel.ImgUrl = "Images/" + Guid.NewGuid().ToString() + "_" + profileViewModel.formFile.FileName;
                var path = System.IO.Path.Combine(_Web.WebRootPath, profileViewModel.ImgUrl);
                await profileViewModel.formFile.CopyToAsync(new FileStream(path, FileMode.Create));

            }
            //await _db.Profiles.AddAsync(new Profile
            //{
            //    Name = profileViewModel.Name,
            //    ImgUrl = profileViewModel.ImgUrl
            //});
            var res = await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
