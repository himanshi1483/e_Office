using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static e_Office.Models.EnumModel;

namespace e_Office.Models
{

    public class UserLogs
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime? LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        public string UserIP { get; set; }

    }

    public class UserActivity
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ActivityDetail { get; set; }
        public DateTime ActivityTime { get; set; }
    }

    public class UserDetails
    {
        [Key]
        public int UserDetailId { get; set; }
        public string Salutation { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name = "Phone Number")]

        public string PhoneNo { get; set; }
        [Display(Name = "Date of Birth")]

        public DateTime? DOB { get; set; }
        [Display(Name = "Is Head of Department?")]

        public bool IsHOD { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [Display(Name = "Department")]
        public int DeptId { get; set; }

        [ForeignKey("DeptId")]
        public virtual DeptMaster Department { get; set; }

        [Display(Name = "Designation")]
        public int DesignationId { get; set; }

        [ForeignKey("DesignationId")]
        public virtual DesignationMaster Designation { get; set; }

        [Display(Name = "Authority")]
        public int AuthorityId { get; set; }

        [ForeignKey("AuthorityId")]
        public virtual AuthorityMaster Authority { get; set; }
    }
}