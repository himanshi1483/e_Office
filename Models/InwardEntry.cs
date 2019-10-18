using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace e_Office.Models
{
    public class InwardEntry
    {
        [Key]
        public int InwardId { get; set; }
        [Display(Name ="Upload File")]
        public string DocumentLocation { get; set; }

        public string DocumentName { get; set; }
        [Display(Name = "Inward No.")]
        public string InwardNumber { get; set; }
        [Display(Name = "Inward Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InwardDate { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }
        [Display(Name = "Due Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DueDate { get; set; }
        public string Action { get; set; }
        public string Priority { get; set; }
        public string Remarks { get; set; }
        public string Tags { get; set; }

        [Display(Name = "Classification")]
        public int Classification { get; set; }

        [ForeignKey("Classification")]
        public virtual ClassificationMaster ClassificationMaster { get; set; }

        [Display(Name = "Send To Department")]
        public int SendToDept { get; set; }

        [ForeignKey("SendToDept")]
        public virtual DeptMaster Department { get; set; }

        [Display(Name = "Send to User")]
        public int SendToUser { get; set; }

        [ForeignKey("SendToUser")]
        public virtual UserDetails UserDetails1 { get; set; }

        [Display(Name = "CC")]
        [NotMapped]
        public List<int> SendToCC { get; set; }
        public string CC { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [NotMapped]
        public List<InwardNotes> NotesList { get; set; }

        [NotMapped]
        public InwardNotes Notes { get; set; }
        [NotMapped]
        public string ErrorMsg { get; set; }

        [NotMapped]
        public string NoteText { get; set; }

        [NotMapped]
        public int NoteId { get; set; }
        [NotMapped]
        public List<string> ForwardedTo { get; set; }


    }
}