using e_Office.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace e_Office.Controllers
{
    public class CategoryMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CategoryMasters
        public ActionResult Index(string status)
        {
            if(status == null)
            {
                ViewBag.CategoryDelete = null;
            }
            else
            {
                ViewBag.CategoryDelete = "Category cannot be deleted.";
            }
            return View(db.CategoryMasters.ToList());
        }

        // GET: CategoryMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMaster categoryMaster = db.CategoryMasters.Find(id);
            if (categoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(categoryMaster);
        }

        // GET: CategoryMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName")] CategoryMaster categoryMaster)
        {
            if (ModelState.IsValid)
            {
                db.CategoryMasters.Add(categoryMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryMaster);
        }

        // GET: CategoryMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMaster categoryMaster = db.CategoryMasters.Find(id);
            if (categoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(categoryMaster);
        }

        // POST: CategoryMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName")] CategoryMaster categoryMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryMaster);
        }

        // GET: CategoryMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMaster categoryMaster = db.CategoryMasters.Find(id);
            if (categoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(categoryMaster);
        }

        // POST: CategoryMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryMaster categoryMaster = db.CategoryMasters.Find(id);
            if (db.SubCategoryMasters.Any(x => x.CategoryId == id))
            {
                ViewBag.CategoryDelete = "This Category cannot be deleted as it is already in use.";
                return RedirectToAction("Index", "CategoryMasters",new { status = "Delete" });
            }
            else
            {
                ViewBag.CategoryDelete = null;
                db.CategoryMasters.Remove(categoryMaster);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
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
