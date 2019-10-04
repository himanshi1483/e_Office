﻿using e_Office.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace e_Office.Controllers
{
    public class InwardEntriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InwardEntries
        public ActionResult Index()
        {
            return View(db.InwardEntries.ToList());
        }

        // GET: InwardEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InwardEntry inwardEntry = db.InwardEntries.Find(id);
            if (inwardEntry == null)
            {
                return HttpNotFound();
            }
            return View(inwardEntry);
        }

        // GET: InwardEntries/Create
        public ActionResult Create()
        {
            var model = new InwardEntry();
            ViewBag.SendToDept = new SelectList(db.DeptMasters, "DeptId", "DeptName", model.SendToDept);
            var users = db.UserDetails.Select(s => new
            {
                UserDetailId = s.UserDetailId,
                FullName = s.FirstName + " " + s.LastName
            }).ToList();

            ViewBag.SendToCC = new SelectList(users, "UserDetailId", "FullName", model.SendToCC);
            ViewBag.SendToUser = new SelectList(users, "UserDetailId", "FullName", model.SendToUser);
            ViewBag.Classification = new SelectList(db.ClassificationMasters, "ClassificationId", "ClassificationName", model.Classification);
            return View(model);
        }

       

        // POST: InwardEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InwardId,DocumentLocation,InwardNumber,InwardDate,Subject,SendToDept,SendToUser,SendToCC,From,DueDate,Action,Priority,Classification,Remarks,Tags")] InwardEntry inwardEntry)
        {
            if (ModelState.IsValid)
            {
                db.InwardEntries.Add(inwardEntry);
                db.SaveChanges();
                ViewBag.SendToDept = new SelectList(db.DeptMasters, "DeptId", "DeptName", inwardEntry.SendToDept);
                var users = db.UserDetails.Select(s => new
                {
                    UserDetailId = s.UserDetailId,
                    FullName = s.FirstName + " " + s.LastName
                }).ToList();

                ViewBag.SendToCC = new SelectList(users, "UserDetailId", "FullName", inwardEntry.SendToCC);
                ViewBag.SendToUser = new SelectList(users, "UserDetailId", "FullName", inwardEntry.SendToUser);
                ViewBag.Classification = new SelectList(db.ClassificationMasters, "ClassificationId", "ClassificationName", inwardEntry.Classification);
                return RedirectToAction("Index");
            }

            return View(inwardEntry);
        }

        // GET: InwardEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InwardEntry inwardEntry = db.InwardEntries.Find(id);
            ViewBag.SendToDept = new SelectList(db.DeptMasters, "DeptId", "DeptName", inwardEntry.SendToDept);
            var users = db.UserDetails.Select(s => new
                            {
                                UserDetailId = s.UserDetailId,
                                FullName = s.FirstName + " " + s.LastName
                            }).ToList();

            ViewBag.SendToCC = new SelectList(users, "UserDetailId", "FullName", inwardEntry.SendToCC);
            ViewBag.SendToUser = new SelectList(users, "UserDetailId", "FullName", inwardEntry.SendToUser);
            ViewBag.Classification = new SelectList(db.ClassificationMasters, "ClassificationId", "ClassificationName", inwardEntry.Classification);
            if (inwardEntry == null)
            {
                return HttpNotFound();
            }
            return View(inwardEntry);
        }

        // POST: InwardEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InwardId,DocumentLocation,InwardNumber,InwardDate,Subject,SendToDept,SendToUser,SendToCC,From,DueDate,Action,Priority,Classification,Remarks,Tags")] InwardEntry inwardEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inwardEntry).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.SendToDept = new SelectList(db.DeptMasters, "DeptId", "DeptName", inwardEntry.SendToDept);
            var users = db.UserDetails.Select(s => new
            {
                UserDetailId = s.UserDetailId,
                FullName = s.FirstName + " " + s.LastName
            }).ToList();

            ViewBag.SendToCC = new SelectList(users, "UserDetailId", "FullName", inwardEntry.SendToCC);
            ViewBag.SendToUser = new SelectList(users, "UserDetailId", "FullName", inwardEntry.SendToUser);
            ViewBag.Classification = new SelectList(db.ClassificationMasters, "ClassificationId", "ClassificationName", inwardEntry.Classification);

            return View(inwardEntry);
        }

        // GET: InwardEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InwardEntry inwardEntry = db.InwardEntries.Find(id);
            if (inwardEntry == null)
            {
                return HttpNotFound();
            }
            return View(inwardEntry);
        }

        // POST: InwardEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InwardEntry inwardEntry = db.InwardEntries.Find(id);
            db.InwardEntries.Remove(inwardEntry);
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
