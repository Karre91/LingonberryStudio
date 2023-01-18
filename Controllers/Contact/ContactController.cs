namespace LingonberryStudio.Controllers.Contact
{
    using System.Net;
    using System.Net.Mail;
    using LingonberryStudio.Models;
    using Microsoft.AspNetCore.Mvc;

    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Contact(Gmail objModelMail)
        {
            objModelMail.To = "lingonberrystudio@gmail.com";
            if (ModelState.IsValid && objModelMail is not null)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(objModelMail.To);
#pragma warning disable CS8604 // Possible null reference argument.
                mail.From = new MailAddress(objModelMail.From);
#pragma warning restore CS8604 // Possible null reference argument.
                mail.Subject = objModelMail.Subject;
                string body = $"{objModelMail.Body} sender {objModelMail.From} Name: {objModelMail.Name}";
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("lingonberrystudio@gmail.com", "mzukfalqsmhgodpm");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                ViewBag.Message = "Thank you for your message!";
                ModelState.Clear();
                return View();
            }
            else
            {
                ViewBag.Message = "Oops something went wrong, please try again!";
                ModelState.Clear();
                return View();
            }
        }
    }
}
