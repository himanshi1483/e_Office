using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static e_Office.Models.EnumModel;

namespace e_Office.Models
{
    public class TaskModel
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskSummary { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }

        public string TaskPriority { get; set; }

        public bool IsComplete { get; set; }
        public string AssignedTo { get; set; }


    }
}