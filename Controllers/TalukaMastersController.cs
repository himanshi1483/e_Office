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
    public class TalukaMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TalukaMasters
        public ActionResult Index()
        {
            return View(db.TalukaMasters.ToList());
        }

        // GET: TalukaMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalukaMaster talukaMaster = db.TalukaMasters.Find(id);
            if (talukaMaster == null)
            {
                return HttpNotFound();
            }
            return View(talukaMaster);
        }

        // GET: TalukaMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TalukaMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TalukaId,TalukaName,TalukaCode,DistrictCode,StateCode")] TalukaMaster talukaMaster)
        {
            if (ModelState.IsValid)
            {
                db.TalukaMasters.Add(talukaMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(talukaMaster);
        }

        // GET: TalukaMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalukaMaster talukaMaster = db.TalukaMasters.Find(id);
            if (talukaMaster == null)
            {
                return HttpNotFound();
            }
            return View(talukaMaster);
        }

        // POST: TalukaMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TalukaId,TalukaName,TalukaCode,DistrictCode,StateCode")] TalukaMaster talukaMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talukaMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(talukaMaster);
        }

        // GET: TalukaMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TalukaMaster talukaMaster = db.TalukaMasters.Find(id);
            if (talukaMaster == null)
            {
                return HttpNotFound();
            }
            return View(talukaMaster);
        }

        // POST: TalukaMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TalukaMaster talukaMaster = db.TalukaMasters.Find(id);
            db.TalukaMasters.Remove(talukaMaster);
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
