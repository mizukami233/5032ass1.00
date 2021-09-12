using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _5032ass1._00.Models;

namespace _5032ass1._00.Controllers
{
    public class ClassSetsController : Controller
    {
        private Model1 db = new Model1();

        // GET: ClassSets
        public ActionResult Index()
        {
            return View(db.ClassSets.ToList());
        }

        // GET: ClassSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSet classSet = db.ClassSets.Find(id);
            if (classSet == null)
            {
                return HttpNotFound();
            }
            return View(classSet);
        }

        // GET: ClassSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassSets/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Class_Name,Class_Des,Class_Rate,Class_Lng,Class_Lat,Class_Date")] ClassSet classSet)
        {
            if (ModelState.IsValid)
            {
                db.ClassSets.Add(classSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classSet);
        }

        // GET: ClassSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSet classSet = db.ClassSets.Find(id);
            if (classSet == null)
            {
                return HttpNotFound();
            }
            return View(classSet);
        }

        // POST: ClassSets/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Class_Name,Class_Des,Class_Rate,Class_Lng,Class_Lat,Class_Date")] ClassSet classSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classSet);
        }

        // GET: ClassSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSet classSet = db.ClassSets.Find(id);
            if (classSet == null)
            {
                return HttpNotFound();
            }
            return View(classSet);
        }

        // POST: ClassSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassSet classSet = db.ClassSets.Find(id);
            db.ClassSets.Remove(classSet);
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
    }
}
