﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public bool IsSigned { get; set; }
        public string DigitalSign { get; set; }
        public string ForwardedTo { get; set; }
        public string ReplyTo { get; set; }
        public string FwdToDept { get; set; }
        public string FwdToCC { get; set; }
        public string ReplyToDept { get; set; }
        public string ReplyToCC { get; set; }
        public string ForwardedBy { get; set; }
        public DateTime? ForwardedOn { get; set; }
        public int RepliedToNote { get; set; }

        public string InwardDoc { get; set; }

        [NotMapped]
        public string ReplyText { get; set; }

    }
}