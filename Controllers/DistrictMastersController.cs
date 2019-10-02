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
    public class DistrictMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DistrictMasters
        public ActionResult Index()
        {
            return View(db.DistrictMasters.ToList());
        }

        // GET: DistrictMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistrictMaster districtMaster = db.DistrictMasters.Find(id);
            if (districtMaster == null)
            {
                return HttpNotFound();
            }
            return View(districtMaster);
        }

        // GET: DistrictMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DistrictMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DistrictId,DistrictName,DistrictCode,StateCode")] DistrictMaster districtMaster)
        {
            if (ModelState.IsValid)
            {
                db.DistrictMasters.Add(districtMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(districtMaster);
        }

        // GET: DistrictMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistrictMaster districtMaster = db.DistrictMasters.Find(id);
            if (districtMaster == null)
            {
                return HttpNotFound();
            }
            return View(districtMaster);
        }

        // POST: DistrictMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DistrictId,DistrictName,DistrictCode,StateCode")] DistrictMaster districtMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(districtMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(districtMaster);
        }

        // GET: DistrictMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistrictMaster districtMaster = db.DistrictMasters.Find(id);
            if (districtMaster == null)
            {
                return HttpNotFound();
            }
            return View(districtMaster);
        }

        // POST: DistrictMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DistrictMaster districtMaster = db.DistrictMasters.Find(id);
            db.DistrictMasters.Remove(districtMaster);
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
