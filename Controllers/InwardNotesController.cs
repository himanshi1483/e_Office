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
        // GET: InwardNotes
        [HttpPost]
        public ActionResult AddGreenNote(FormCollection formdata, HttpPostedFileBase files1)
        {
            var model = new InwardEntry();
            model.Notes = new InwardNotes();
            model.Notes.NoteType = "Green";
            model.Notes.NoteText = Request.Form["NoteText"].ToString();
            model.Notes.CreatedBy = User.Identity.Name;
            model.Notes.CreatedDate = DateTime.Now;
            model.Notes.IsSigned = true;
            model.Notes.InwardId = Convert.ToInt32(Request.Form["InwardId"]);
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
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        [HttpPost]
        public ActionResult AddYellowNote(FormCollection formdata, HttpPostedFileBase files1)
        {
            var model = new InwardEntry();
            model.Notes = new InwardNotes();
            model.Notes.NoteType = "Yellow";
            model.Notes.NoteText = Request.Form["NoteText"].ToString();
            model.Notes.CreatedBy = User.Identity.Name;
            model.Notes.CreatedDate = DateTime.Now;
            model.Notes.IsSigned = true;
            model.Notes.InwardId = Convert.ToInt32(Request.Form["InwardId"]);
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
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        [HttpPost]
        public ActionResult ForwardNote(InwardEntry model)
        {
            var note = new InwardNotes();
            note = db.InwardNotes.Find(model.NoteId);
            note.ForwardedTo = string.Join(",", model.ForwardedTo);
            note.ForwardedBy = User.Identity.Name;
            note.ForwardedOn = DateTime.Now;
            db.Entry(note).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        [HttpPost]
        public ActionResult ReplyNote(InwardEntry model)
        {
            var note = new InwardNotes();
            note = db.InwardNotes.Find(model.NoteId);
            note.RepliedToNote = note.NotesId;
            note.CreatedBy = User.Identity.Name;
            note.CreatedDate = DateTime.Now;
            note.NoteText = model.NoteText;
            db.InwardNotes.Add(note);
            //db.Entry(note).State = EntityState.Modified;
            db.SaveChanges();
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