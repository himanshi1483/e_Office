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
    public class DeptMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeptMasters
        public ActionResult Index()
        {
            return View(db.DeptMasters.ToList());
        }

        // GET: DeptMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeptMaster deptMaster = db.DeptMasters.Find(id);
            if (deptMaster == null)
            {
                return HttpNotFound();
            }
            return View(deptMaster);
        }

        // GET: DeptMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeptMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeptId,DeptName,DeptCode")] DeptMaster deptMaster)
        {
            if (ModelState.IsValid)
            {
                db.DeptMasters.Add(deptMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deptMaster);
        }

        // GET: DeptMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeptMaster deptMaster = db.DeptMasters.Find(id);
            if (deptMaster == null)
            {
                return HttpNotFound();
            }
            return View(deptMaster);
        }

        // POST: DeptMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeptId,DeptName,DeptCode")] DeptMaster deptMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deptMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deptMaster);
        }

        // GET: DeptMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeptMaster deptMaster = db.DeptMasters.Find(id);
            if (deptMaster == null)
            {
                return HttpNotFound();
            }
            return View(deptMaster);
        }

        // POST: DeptMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeptMaster deptMaster = db.DeptMasters.Find(id);
            db.DeptMasters.Remove(deptMaster);
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
