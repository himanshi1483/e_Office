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
    public class BasicHeadMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BasicHeadMasters
        public ActionResult Index()
        {
            return View(db.BasicHeadMasters.ToList());
        }

        // GET: BasicHeadMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasicHeadMaster basicHeadMaster = db.BasicHeadMasters.Find(id);
            if (basicHeadMaster == null)
            {
                return HttpNotFound();
            }
            return View(basicHeadMaster);
        }

        // GET: BasicHeadMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BasicHeadMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BasicHeadId,BasicHeadName")] BasicHeadMaster basicHeadMaster)
        {
            if (ModelState.IsValid)
            {
                db.BasicHeadMasters.Add(basicHeadMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(basicHeadMaster);
        }

        // GET: BasicHeadMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasicHeadMaster basicHeadMaster = db.BasicHeadMasters.Find(id);
            if (basicHeadMaster == null)
            {
                return HttpNotFound();
            }
            return View(basicHeadMaster);
        }

        // POST: BasicHeadMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BasicHeadId,BasicHeadName")] BasicHeadMaster basicHeadMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basicHeadMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(basicHeadMaster);
        }

        // GET: BasicHeadMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasicHeadMaster basicHeadMaster = db.BasicHeadMasters.Find(id);
            if (basicHeadMaster == null)
            {
                return HttpNotFound();
            }
            return View(basicHeadMaster);
        }

        // POST: BasicHeadMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BasicHeadMaster basicHeadMaster = db.BasicHeadMasters.Find(id);
            db.BasicHeadMasters.Remove(basicHeadMaster);
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
