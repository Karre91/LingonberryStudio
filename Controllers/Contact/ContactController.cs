using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using LingonberryStudio.Models;

namespace LingonberryStudio.Controllers.Contact
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
			return View();
		}


        [HttpPost]
        public IActionResult Contact(LingonberryStudio.Models.Gmail _objModelMail)
        {
            _objModelMail.To = "lingonberrystudio@gmail.com";
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = $"{_objModelMail.Body} sender {_objModelMail.From} Name: {_objModelMail.Name}";
                mail.Body = Body;
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
