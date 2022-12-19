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
        public IActionResult Contact(LingonberryStudio.Models.gmail _objModelMail)
		{
          

            if (ModelState.IsValid)
				{

                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
					mail.Subject = _objModelMail.Subject;
					string Body = $"{_objModelMail.Body} sender {_objModelMail.From}";
					mail.Body = Body;
					mail.IsBodyHtml = true;
					SmtpClient smtp = new SmtpClient();
					smtp.Host = "smtp.gmail.com";
					smtp.Port = 587;
					smtp.UseDefaultCredentials = false;
					smtp.Credentials = new System.Net.NetworkCredential("lingonberrystudio@gmail.com", "mzukfalqsmhgodpm"); // Enter seders User name and password  
					smtp.EnableSsl = true;
					smtp.Send(mail);

				return View("Index", _objModelMail);
				}
				else
				{
					return View();
				}
		
		}
    }
}
