using e_Office.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult AddGreenNote(InwardEntry model)
        {
            model.Notes = new InwardNotes();
            model.Notes.NoteType = "Green";
            model.Notes.NoteText = model.NoteText;
            model.Notes.CreatedBy = User.Identity.Name;
            model.Notes.CreatedDate = DateTime.Now;
            model.Notes.IsSigned = false;
            model.Notes.InwardId = model.InwardId;
            db.InwardNotes.Add(model.Notes);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        [HttpPost]
        public ActionResult AddYellowNote(InwardEntry model)
        {
            model.Notes = new InwardNotes();
            model.Notes.NoteType = "Yellow";
            model.Notes.NoteText = model.NoteText;
            model.Notes.CreatedBy = User.Identity.Name;
            model.Notes.CreatedDate = DateTime.Now;
            model.Notes.IsSigned = false;
            model.Notes.InwardId = model.InwardId;
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
    }
}