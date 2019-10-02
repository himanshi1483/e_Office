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
    public class AuthorityMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AuthorityMasters
        public ActionResult Index()
        {
            return View(db.AuthorityMasters.ToList());
        }

        // GET: AuthorityMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorityMaster authorityMaster = db.AuthorityMasters.Find(id);
            if (authorityMaster == null)
            {
                return HttpNotFound();
            }
            return View(authorityMaster);
        }

        // GET: AuthorityMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorityMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthorityId,AuthorityName,AuthorityCode")] AuthorityMaster authorityMaster)
        {
            if (ModelState.IsValid)
            {
                db.AuthorityMasters.Add(authorityMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authorityMaster);
        }

        // GET: AuthorityMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorityMaster authorityMaster = db.AuthorityMasters.Find(id);
            if (authorityMaster == null)
            {
                return HttpNotFound();
            }
            return View(authorityMaster);
        }

        // POST: AuthorityMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthorityId,AuthorityName,AuthorityCode")] AuthorityMaster authorityMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorityMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorityMaster);
        }

        // GET: AuthorityMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorityMaster authorityMaster = db.AuthorityMasters.Find(id);
            if (authorityMaster == null)
            {
                return HttpNotFound();
            }
            return View(authorityMaster);
        }

        // POST: AuthorityMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuthorityMaster authorityMaster = db.AuthorityMasters.Find(id);
            db.AuthorityMasters.Remove(authorityMaster);
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
