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
    public class SubHeadMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubHeadMasters
        public ActionResult Index()
        {
            return View(db.SubHeadMasters.ToList());
        }

        // GET: SubHeadMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubHeadMaster subHeadMaster = db.SubHeadMasters.Find(id);
            if (subHeadMaster == null)
            {
                return HttpNotFound();
            }
            return View(subHeadMaster);
        }

        // GET: SubHeadMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubHeadMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubHeadId")] SubHeadMaster subHeadMaster)
        {
            if (ModelState.IsValid)
            {
                db.SubHeadMasters.Add(subHeadMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subHeadMaster);
        }

        // GET: SubHeadMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubHeadMaster subHeadMaster = db.SubHeadMasters.Find(id);
            if (subHeadMaster == null)
            {
                return HttpNotFound();
            }
            return View(subHeadMaster);
        }

        // POST: SubHeadMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubHeadId")] SubHeadMaster subHeadMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subHeadMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subHeadMaster);
        }

        // GET: SubHeadMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubHeadMaster subHeadMaster = db.SubHeadMasters.Find(id);
            if (subHeadMaster == null)
            {
                return HttpNotFound();
            }
            return View(subHeadMaster);
        }

        // POST: SubHeadMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubHeadMaster subHeadMaster = db.SubHeadMasters.Find(id);
            db.SubHeadMasters.Remove(subHeadMaster);
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
