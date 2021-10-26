using _5032ass1._00.Models;
using _5032ass1._00.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace _5032ass1._00.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();
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
        //public ActionResult Send_Email(SendEmailViewModel sendEmailViewModel)
        //{
        //    var bookingList = db.BookingSets.ToList();
        //    foreach (var bk in bookingList)
        //    {
        //        MailAddress to = new MailAddress(bk.Booking_Email);
        //        MailAddress from = new MailAddress("b29e29fcc2 - afe465@inbox.mailtrap.io");
        //        MailMessage message = new MailMessage(from, to);
        //        message.Subject = sendEmailViewModel.Subject;
        //        message.Body = sendEmailViewModel.Contents;
        //        if (ModelState.IsValid)
        //        {

        //            SmtpClient client = new SmtpClient("smtp.mailtrap.io", 2525)
        //            {
        //                Credentials = new NetworkCredential("d93b02cc045bd7", "6d257a76decd00"),
        //                EnableSsl = true
        //            };
        //            // code in brackets above needed if authentication required

        //            try
        //            {

        //                client.Send(message);
        //            }
        //            catch (SmtpException ex)
        //            {
        //                Console.WriteLine(ex.ToString());
        //            }
        //            /* ViewBag.Result = "Email has been send.";
        //             return View(); //return this page*/
        //        }

        //    }


        //    return View();
        //}
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Send_Email([Bind(Include = "Subject,Body")] SendEmailViewModel sendEmailViewModel, HttpPostedFileBase postedFile)
        {
            var bookingList = db.BookingSets.ToList();
            var emailList = new ArrayList();
            var count = 0;
            foreach (var bk in bookingList)
            {
                if (!emailList.Contains(bk.Booking_Email))
                {
                    emailList.Add(bk.Booking_Email);
               
             
                 MailAddress to = new MailAddress(bk.Booking_Email);
                MailAddress from = new MailAddress("b29e29fcc2 - afe465@inbox.mailtrap.io");
                MailMessage message = new MailMessage(from, to);
                message.Subject = sendEmailViewModel.Subject;
                message.Body = sendEmailViewModel.Contents;
                var myUniqueFileName = string.Format(@"{0}", Guid.NewGuid());

                    string serverPath = Server.MapPath("~/Uploads/");
                    string fileExtension = Path.GetExtension(postedFile.FileName);
                    string filePath = myUniqueFileName + fileExtension;
                    string fullPath = serverPath + filePath;
                    postedFile.SaveAs(fullPath);

                    SmtpClient client = new SmtpClient("smtp.mailtrap.io", 2525)
                    {
                        Credentials = new NetworkCredential("d93b02cc045bd7", "6d257a76decd00"),
                        EnableSsl = true
                    };
                    // code in brackets above needed if authentication required
                    var attachment = new System.Net.Mail.Attachment(fullPath);
                    message.Attachments.Add(attachment);

                    try
                    {
                        client.Send(message);
                        count++;


                    }
                    catch (SmtpException ex)
                    {
                        Console.WriteLine(ex.ToString());
                        ViewBag.Result = ex.ToString();
                        return View(sendEmailViewModel);
                    }
                    /* db.emailsending.Add(emailsending);
                     db.SaveChanges();*/
                    //return RedirectToAction("Index");
                }

            }
            ViewBag.Result = "Email has been successfully. Total number of emails: "+ count;
            return View(sendEmailViewModel);
        }
    }
}