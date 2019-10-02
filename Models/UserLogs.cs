using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNo { get; set; }
        public DateTime DOB { get; set; }
        public int DeptId { get; set; }
        public int DesignationId { get; set; }
        public int AuthorityId { get; set; }
        public bool IsHOD { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}