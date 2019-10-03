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
    public class SubCategoryMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubCategoryMasters
        public ActionResult Index()
        {
            return View(db.SubCategoryMasters.ToList());
        }

        // GET: SubCategoryMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoryMaster subCategoryMaster = db.SubCategoryMasters.Find(id);
            if (subCategoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryMaster);
        }

        // GET: SubCategoryMasters/Create
        public ActionResult Create()
        {
            var model = new SubCategoryMaster();
           // model.Category = db.CategoryMasters.ToList();
            ViewBag.CategoryId = new SelectList(db.CategoryMasters, "CategoryId", "CategoryName", model.CategoryId);
            return View(model);
        }

        // POST: SubCategoryMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubCategoryId,SubCategoryName,CategoryId")] SubCategoryMaster subCategoryMaster)
        {
            if (ModelState.IsValid)
            {
                db.SubCategoryMasters.Add(subCategoryMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.CategoryMasters, "CategoryId", "CategoryName", subCategoryMaster.CategoryId);
            return View(subCategoryMaster);
        }

        // GET: SubCategoryMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoryMaster subCategoryMaster = db.SubCategoryMasters.Find(id);
            ViewBag.CategoryId = new SelectList(db.CategoryMasters, "CategoryId", "CategoryName", subCategoryMaster.CategoryId);

            if (subCategoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryMaster);
        }

        // POST: SubCategoryMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubCategoryId,SubCategoryName,CategoryId")] SubCategoryMaster subCategoryMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCategoryMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.CategoryMasters, "CategoryId", "CategoryName", subCategoryMaster.CategoryId);
            return View(subCategoryMaster);
        }

        // GET: SubCategoryMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoryMaster subCategoryMaster = db.SubCategoryMasters.Find(id);
            if (subCategoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryMaster);
        }

        // POST: SubCategoryMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCategoryMaster subCategoryMaster = db.SubCategoryMasters.Find(id);

            db.SubCategoryMasters.Remove(subCategoryMaster);
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
