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
    public class DesignationMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DesignationMasters
        public ActionResult Index()
        {
            return View(db.DesignationMasters.ToList());
        }

        // GET: DesignationMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignationMaster designationMaster = db.DesignationMasters.Find(id);
            if (designationMaster == null)
            {
                return HttpNotFound();
            }
            return View(designationMaster);
        }

        // GET: DesignationMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DesignationMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DesignationId,DesignationName,DesignationCode")] DesignationMaster designationMaster)
        {
            if (ModelState.IsValid)
            {
                db.DesignationMasters.Add(designationMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(designationMaster);
        }

        // GET: DesignationMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignationMaster designationMaster = db.DesignationMasters.Find(id);
            if (designationMaster == null)
            {
                return HttpNotFound();
            }
            return View(designationMaster);
        }

        // POST: DesignationMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DesignationId,DesignationName,DesignationCode")] DesignationMaster designationMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designationMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(designationMaster);
        }

        // GET: DesignationMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignationMaster designationMaster = db.DesignationMasters.Find(id);
            if (designationMaster == null)
            {
                return HttpNotFound();
            }
            return View(designationMaster);
        }

        // POST: DesignationMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DesignationMaster designationMaster = db.DesignationMasters.Find(id);
            db.DesignationMasters.Remove(designationMaster);
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
