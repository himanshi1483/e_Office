using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using e_Office.Models;

namespace e_Office.Controllers
{
    public class ClassificationMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClassificationMasters
        public ActionResult Index()
        {
            return View(db.ClassificationMasters.ToList());
        }

        // GET: ClassificationMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassificationMaster classificationMaster = db.ClassificationMasters.Find(id);
            if (classificationMaster == null)
            {
                return HttpNotFound();
            }
            return View(classificationMaster);
        }

        // GET: ClassificationMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassificationMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassificationId,ClassificationName,ClassificationCode")] ClassificationMaster classificationMaster)
        {
            if (ModelState.IsValid)
            {
                db.ClassificationMasters.Add(classificationMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classificationMaster);
        }

        // GET: ClassificationMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassificationMaster classificationMaster = db.ClassificationMasters.Find(id);
            if (classificationMaster == null)
            {
                return HttpNotFound();
            }
            return View(classificationMaster);
        }

        // POST: ClassificationMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassificationId,ClassificationName,ClassificationCode")] ClassificationMaster classificationMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classificationMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classificationMaster);
        }

        // GET: ClassificationMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassificationMaster classificationMaster = db.ClassificationMasters.Find(id);
            if (classificationMaster == null)
            {
                return HttpNotFound();
            }
            return View(classificationMaster);
        }

        // POST: ClassificationMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassificationMaster classificationMaster = db.ClassificationMasters.Find(id);
            db.ClassificationMasters.Remove(classificationMaster);
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
