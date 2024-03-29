﻿using System;
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
    public class StateMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StateMasters
        public ActionResult Index()
        {
            return View(db.StateMasters.ToList());
        }

        // GET: StateMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateMaster stateMaster = db.StateMasters.Find(id);
            if (stateMaster == null)
            {
                return HttpNotFound();
            }
            return View(stateMaster);
        }

        // GET: StateMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StateMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StateId,StateName,StateCode")] StateMaster stateMaster)
        {
            if (ModelState.IsValid)
            {
                db.StateMasters.Add(stateMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stateMaster);
        }

        // GET: StateMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateMaster stateMaster = db.StateMasters.Find(id);
            if (stateMaster == null)
            {
                return HttpNotFound();
            }
            return View(stateMaster);
        }

        // POST: StateMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StateId,StateName,StateCode")] StateMaster stateMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stateMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stateMaster);
        }

        // GET: StateMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateMaster stateMaster = db.StateMasters.Find(id);
            if (stateMaster == null)
            {
                return HttpNotFound();
            }
            return View(stateMaster);
        }

        // POST: StateMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StateMaster stateMaster = db.StateMasters.Find(id);
            db.StateMasters.Remove(stateMaster);
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
