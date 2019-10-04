using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using e_Office.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace e_Office.Controllers
{
    public class UserDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserDetails
        public ActionResult Index()
        {
            return View(db.UserDetails.ToList());
        }

        // GET: UserDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = db.UserDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        public JsonResult GetPassword()
        {
            var pwd = CreateRandomPassword(8);
            return Json(pwd);
        }

        private static string CreateRandomPassword(int passwordLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        public JsonResult CheckUser(string user)
        {
            var username = user;
            var isUser = db.Users.Any(x => x.UserName == user);
            int i = 1;

            while (isUser)
            {
                username = String.Concat(user, i);
                isUser = db.Users.Any(x => x.UserName == username);
                i = i+1;
            }

            return Json(username);
        }

        // GET: UserDetails/Create
        public ActionResult Create()
        {
            var model = new UserDetails();
            ViewBag.DeptId = new SelectList(db.DeptMasters, "DeptId", "DeptName", model.DeptId);
            ViewBag.DesignationId = new SelectList(db.DesignationMasters, "DesignationId", "DesignationName", model.DesignationId);
            ViewBag.AuthorityId = new SelectList(db.AuthorityMasters, "AuthorityId", "AuthorityName", model.AuthorityId);

            return View(model);
        }

        // POST: UserDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserDetailId,Salutation,FirstName,MiddleName,LastName,Gender,EmailAddress,PhoneNo,DOB,DeptId,DesignationId,AuthorityId,IsHOD,Username,Password")] UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                db.UserDetails.Add(userDetails);
                db.SaveChanges();

                UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(db);
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var user = new ApplicationUser();

                user.UserName = userDetails.Username.ToString();
                user.Email = userDetails.EmailAddress;
                String hashedNewPassword = UserManager.PasswordHasher.HashPassword(userDetails.Password);
                user.PasswordHash = hashedNewPassword;
                var chkUser = UserManager.Create(user, userDetails.Password);

                //Add default User to Role User    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "User");
                }
                return RedirectToAction("Index");
            }
            ViewBag.DeptId = new SelectList(db.DeptMasters, "DeptId", "DeptName", userDetails.DeptId);
            ViewBag.DesignationId = new SelectList(db.DesignationMasters, "DesignationId", "DesignationName", userDetails.DesignationId);
            ViewBag.AuthorityId = new SelectList(db.AuthorityMasters, "AuthorityId", "AuthorityName", userDetails.AuthorityId);
            return View(userDetails);
        }

        // GET: UserDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = db.UserDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptId = new SelectList(db.DeptMasters, "DeptId", "DeptName", userDetails.DeptId);
            ViewBag.DesignationId = new SelectList(db.DesignationMasters, "DesignationId", "DesignationName", userDetails.DesignationId);
            ViewBag.AuthorityId = new SelectList(db.AuthorityMasters, "AuthorityId", "AuthorityName", userDetails.AuthorityId);

            return View(userDetails);
        }

        // POST: UserDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserDetailId,Salutation,FirstName,MiddleName,LastName,Gender,EmailAddress,PhoneNo,DOB,DeptId,DesignationId,AuthorityId,IsHOD,Username,Password")] UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptId = new SelectList(db.DeptMasters, "DeptId", "DeptName", userDetails.DeptId);
            ViewBag.DesignationId = new SelectList(db.DesignationMasters, "DesignationId", "DesignationName", userDetails.DesignationId);
            ViewBag.AuthorityId = new SelectList(db.AuthorityMasters, "AuthorityId", "AuthorityName", userDetails.AuthorityId);
            return View(userDetails);
        }

        // GET: UserDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetails userDetails = db.UserDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // POST: UserDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDetails userDetails = db.UserDetails.Find(id);
            db.UserDetails.Remove(userDetails);
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
