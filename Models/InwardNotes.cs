using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_Office.Models
{
    public class InwardNotes
    {
        [Key]
        public int NotesId { get; set; }
        public int InwardId { get; set; }
        public string NoteType { get; set; }
        public string NoteText { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string IsSigned { get; set; }

    }
}