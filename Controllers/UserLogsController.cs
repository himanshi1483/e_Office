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
    public class UserLogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserLogs
        public ActionResult Index()
        {
            return View(db.UserLogs.ToList());
        }

        // GET: UserLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLogs userLogs = db.UserLogs.Find(id);
            if (userLogs == null)
            {
                return HttpNotFound();
            }
            return View(userLogs);
        }

        // GET: UserLogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,LoginTime,LogoutTime,UserIP")] UserLogs userLogs)
        {
            if (ModelState.IsValid)
            {
                db.UserLogs.Add(userLogs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userLogs);
        }

        // GET: UserLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLogs userLogs = db.UserLogs.Find(id);
            if (userLogs == null)
            {
                return HttpNotFound();
            }
            return View(userLogs);
        }

        // POST: UserLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,LoginTime,LogoutTime,UserIP")] UserLogs userLogs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userLogs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userLogs);
        }

        // GET: UserLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLogs userLogs = db.UserLogs.Find(id);
            if (userLogs == null)
            {
                return HttpNotFound();
            }
            return View(userLogs);
        }

        // POST: UserLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserLogs userLogs = db.UserLogs.Find(id);
            db.UserLogs.Remove(userLogs);
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
