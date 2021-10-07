using _5032ass1._00.Models;
using _5032ass1._00.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace _5032ass1._00.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Send_Email()
        {
            return View(new SendEmailViewModel());
        }

        [HttpPost]
        public ActionResult Send_Email(SendEmailViewModel sendEmailViewModel)
        {
            MailAddress to = new MailAddress(sendEmailViewModel.ToEmail);
            MailAddress from = new MailAddress("b29e29fcc2 - afe465@inbox.mailtrap.io");
            MailMessage message = new MailMessage(from, to);
            message.Subject = sendEmailViewModel.Subject;
            message.Body = sendEmailViewModel.Contents;
            if (ModelState.IsValid)
            {

                SmtpClient client = new SmtpClient("smtp.mailtrap.io", 2525)
                {
                    Credentials = new NetworkCredential("d93b02cc045bd7", "6d257a76decd00"),
                    EnableSsl = true
                };
                // code in brackets above needed if authentication required

                try
                {
                    client.Send(message);
                }
                catch (SmtpException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                ViewBag.Result = "Email has been send.";
                return View(); //return this page
            }

            return View();
        }
    }
}