using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_Office.Models
{
    public class InwardEntry
    {
        [Key]
        public int InwardId { get; set; }
        public string DocumentLocation { get; set; }
        public string InwardNumber { get; set; }
        public DateTime InwardDate { get; set; }
        public string Subject { get; set; }
        public string SendToDept { get; set; }
        public string SendToUser { get; set; }
        public string SendToCC { get; set; }
        public string From { get; set; }
        public DateTime? DueDate { get; set; }
        public string Action { get; set; }
        public string Priority { get; set; }
        public string Classification { get; set; }
        public string Remarks { get; set; }
        public string Tags { get; set; }
    }
}