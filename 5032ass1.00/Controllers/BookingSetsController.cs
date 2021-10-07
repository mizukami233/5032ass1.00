using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using _5032ass1._00.Models;
using _5032ass1._00.Utils;
using Microsoft.AspNet.Identity;

namespace _5032ass1._00.Controllers
{
    public class BookingSetsController : Controller
    {
        private Model1 db = new Model1();

        // GET: BookingSets
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                var bookings = db.BookingSets.Include(b => b.ClassSet);
                return View(bookings.ToList());
            }
            else
            {
                var id = User.Identity.GetUserId();
                var bookings = db.BookingSets.Where(b => b.User_Id == id);
                return View(bookings.ToList());
            }
        }

        // GET: BookingSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingSet bookingSet = db.BookingSets.Find(id);
            if (bookingSet == null)
            {
                return HttpNotFound();
            }
            return View(bookingSet);
        }

        // GET: BookingSets/Create
        public ActionResult Create(String date)
        {
            BookingSet booking = new BookingSet();

            if(date == null)
            {
                return RedirectToAction("Index");
            }
            DateTime dt = Convert.ToDateTime(date);
            booking.Booking_Date = dt;
            ViewBag.Class_Id = new SelectList(db.ClassSets, "Id", "Class_Name");
            return View(booking);
        }

        // POST: BookingSets/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Booking_Name,Booking_Date,Booking_Email,Booking_Rate,Class_Id")] BookingSet bookingSet)
        {
            DateTimeOffset dateTime = DateTimeOffset.Now;
            if (DateTimeOffset.Compare(bookingSet.Booking_Date, dateTime) < 0) 
            {
                return Content("<script>alert('booking date error');window.location.href = 'Index'</script>");
            }


            EmailAsync(bookingSet.Booking_Email);
            bookingSet.User_Id = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(bookingSet);
            if (ModelState.IsValid)
            {
                db.BookingSets.Add(bookingSet);
                db.SaveChanges();
                return Content("<script>alert('you add class successfully');window.location.href = 'Index'</script>");
                //return RedirectToAction("Index");
            }

            ViewBag.Class_Id = new SelectList(db.ClassSets, "Id", "Class_Name", bookingSet.Class_Id);
            return View(bookingSet);
        }

        // GET: BookingSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingSet bookingSet = db.BookingSets.Find(id);
            if (bookingSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Class_Id = new SelectList(db.ClassSets, "Id", "Class_Name", bookingSet.Class_Id);
            return View(bookingSet);
        }

        // POST: BookingSets/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Booking_Name,Booking_Date,Booking_Email,User_Id,Booking_Rate,Class_Id")] BookingSet bookingSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Class_Id = new SelectList(db.ClassSets, "Id", "Class_Name", bookingSet.Class_Id);
            return View(bookingSet);
        }

        // GET: BookingSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingSet bookingSet = db.BookingSets.Find(id);
            if (bookingSet == null)
            {
                return HttpNotFound();
            }
            return View(bookingSet);
        }

        // POST: BookingSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingSet bookingSet = db.BookingSets.Find(id);
            db.BookingSets.Remove(bookingSet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public Task<ActionResult> EmailAsync(String email) 
        {
            MailAddress to = new MailAddress(email);
            MailAddress from = new MailAddress("b29e29fcc2 - afe465@inbox.mailtrap.io");
            MailMessage message = new MailMessage(from, to);
            message.Subject = "you class add successfully";
            message.Body = "Please login your account to see more class details";


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
                return null;

        }
    }
}
