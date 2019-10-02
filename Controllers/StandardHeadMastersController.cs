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
    public class StandardHeadMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StandardHeadMasters
        public ActionResult Index()
        {
            return View(db.StandardHeadMasters.ToList());
        }

        // GET: StandardHeadMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StandardHeadMaster standardHeadMaster = db.StandardHeadMasters.Find(id);
            if (standardHeadMaster == null)
            {
                return HttpNotFound();
            }
            return View(standardHeadMaster);
        }

        // GET: StandardHeadMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StandardHeadMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StdHeadId")] StandardHeadMaster standardHeadMaster)
        {
            if (ModelState.IsValid)
            {
                db.StandardHeadMasters.Add(standardHeadMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(standardHeadMaster);
        }

        // GET: StandardHeadMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StandardHeadMaster standardHeadMaster = db.StandardHeadMasters.Find(id);
            if (standardHeadMaster == null)
            {
                return HttpNotFound();
            }
            return View(standardHeadMaster);
        }

        // POST: StandardHeadMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StdHeadId")] StandardHeadMaster standardHeadMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(standardHeadMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(standardHeadMaster);
        }

        // GET: StandardHeadMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StandardHeadMaster standardHeadMaster = db.StandardHeadMasters.Find(id);
            if (standardHeadMaster == null)
            {
                return HttpNotFound();
            }
            return View(standardHeadMaster);
        }

        // POST: StandardHeadMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StandardHeadMaster standardHeadMaster = db.StandardHeadMasters.Find(id);
            db.StandardHeadMasters.Remove(standardHeadMaster);
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
