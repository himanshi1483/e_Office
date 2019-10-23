using e_Office.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_Office.Controllers
{
    public class InwardNotesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Inbox()
        {
            var notes = db.InwardNotes.Where(x => x.ForwardedTo.Contains(User.Identity.Name)).ToList();
            var model = new InwardEntry();
            model.NotesList = new List<InwardNotes>();
            model.NotesList = notes;
            return View(notes);
        }

        public ActionResult OutBox()
        {
            var notes = db.InwardNotes.Where(x => x.ForwardedBy == User.Identity.Name || x.CreatedBy == User.Identity.Name && x.RepliedToNote != 0 ).ToList();
            return View(notes);
        }
        // GET: InwardNotes
        [HttpPost]
        public JsonResult AddGreenNote(FormCollection formdata, HttpPostedFileBase files1)
        {
            var model = new InwardEntry();
            model.InwardId = Convert.ToInt32(Request.Form["InwardId"]);
            model = db.InwardEntries.Find(model.InwardId);
            model.Notes = new InwardNotes();
            model.Notes.NoteType = "Green";
            model.Notes.NoteText = Request.Form["NoteText"].ToString();
            model.Notes.CreatedBy = User.Identity.Name;
            model.Notes.CreatedDate = DateTime.Now;
            model.Notes.IsSigned = true;
            model.Notes.InwardId = model.InwardId;
            model.Notes.InwardDoc = model.DocumentLocation;
            if (Request.Files.Count > 0)
            {
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                    //string filename = Path.GetFileName(Request.Files[i].FileName);  

                    HttpPostedFileBase file = files[i];
                    string fname;
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fname = file.FileName;
                    }
                    fname = Path.Combine(Server.MapPath("~/Documents/"), fname);
                    file.SaveAs(fname);
                    model.Notes.DigitalSign = fname;
                }
            }
        
            db.InwardNotes.Add(model.Notes);
            db.SaveChanges();
            TempData["Notification"] = "New Note added by "+ User.Identity.Name;
            // return RedirectToAction("ViewFile", "InwardEntries", new { id = model.InwardId, doc=model.DocumentLocation});
            return Json(new { res = model });
        }

        [HttpPost]
        public JsonResult AddYellowNote(FormCollection formdata, HttpPostedFileBase files1)
        {
            var model = new InwardEntry();
            model.InwardId = Convert.ToInt32(Request.Form["InwardId"]);
            model = db.InwardEntries.Find(model.InwardId);
            model.Notes = new InwardNotes();
            model.Notes.NoteType = "Yellow";
            model.Notes.NoteText = Request.Form["NoteText"].ToString();
            model.Notes.CreatedBy = User.Identity.Name;
            model.Notes.CreatedDate = DateTime.Now;
            model.Notes.IsSigned = true;
            model.Notes.InwardId = model.InwardId;
            model.Notes.InwardDoc = model.DocumentLocation;

            if (Request.Files.Count > 0)
            {
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                    //string filename = Path.GetFileName(Request.Files[i].FileName);  

                    HttpPostedFileBase file = files[i];
                    string fname;
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fname = file.FileName;
                    }
                    fname = Path.Combine(Server.MapPath("~/Documents/"), fname);
                    file.SaveAs(fname);
                    model.Notes.DigitalSign = fname;
                }
            }
            db.InwardNotes.Add(model.Notes);
            db.SaveChanges();
            TempData["Notification"] = "New Note added by " + User.Identity.Name;
            // return RedirectToAction("ViewFile", "InwardEntries", new { id = model.Notes.InwardId, doc = model.DocumentLocation });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ForwardInward(InwardEntry model)
        {
            InwardNotes note = db.InwardNotes.Find(model.NoteId);
            model.Notes = note;
            model.Notes.ForwardedTo = string.Join(",", model.ForwardedTo);
            model.Notes.FwdToCC = string.Join(",", model.FwdToCC);
            model.Notes.FwdToDept = string.Join(",", model.FwdToDept);
            model.Notes.ForwardedBy = User.Identity.Name;
            model.Notes.ForwardedOn = DateTime.Now;
            db.Entry(note).State = EntityState.Modified;
            db.SaveChanges();
            TempData["Notification"] = "Note forwarded by " + User.Identity.Name;
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        [HttpPost]
        public ActionResult ReplyNote(InwardEntry model)
        {
            var note = new InwardNotes();
            model.Notes = new InwardNotes();
            model.Notes = db.InwardNotes.Find(model.NoteId);
            note.RepliedToNote = model.Notes.NotesId;
            note.NoteType = model.Notes.NoteType;
            note.InwardId = model.Notes.InwardId;
            note.ReplyTo = model.Notes.CreatedBy;
            note.ReplyToCC = string.Join(",", model.ReplyToCC);
            note.ReplyToDept = string.Join(",", model.ReplyToDept);
            note.CreatedBy = User.Identity.Name;
            note.CreatedDate = DateTime.Now;
            note.NoteText = model.NoteText;
            note.InwardDoc = model.DocumentLocation;

            db.InwardNotes.Add(note);
            //db.Entry(note).State = EntityState.Modified;
            db.SaveChanges();
            TempData["Notification"] = "Note replied by " + User.Identity.Name;
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        [HttpPost]
        public ActionResult SaveSign(FormCollection data)
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.  
                        //fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                        //file.SaveAs(fname);
                    }
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }
    }
}