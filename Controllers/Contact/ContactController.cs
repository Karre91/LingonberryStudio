using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace LingonberryStudio.Controllers.Contact
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Contact(LingonberryStudio.Models.gmail model)
        {
            MailMessage mailMessage = new MailMessage("lingonberrystudio@gmail.com", model.To);
            mailMessage.Subject = model.Subject;
            mailMessage.Body = model.Body;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("lingonberrystudio@gmail.com", "lösen");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mailMessage);
            ViewBag.Message = "Mail has been sent successfully";
            return View();
        }
    }
}
