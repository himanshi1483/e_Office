using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_Office.Models
{
    public class DesignationMaster
    {
        [Key]
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public string DesignationCode { get; set; }
    }

    public class AuthorityMaster
    {
        [Key]
        public int AuthorityId { get; set; }
        public string AuthorityName { get; set; }
        public string AuthorityCode { get; set; }
    }

    public class DeptMaster
    {
        [Key]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptCode { get; set; }
    }

    public class ClassificationMaster
    {
        [Key]
        public int ClassificationId { get; set; }
        public string ClassificationName { get; set; }
        public string ClassificationCode { get; set; }
    }

    public class StateMaster
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
    }

    public class DistrictMaster
    {
        [Key]
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string DistrictCode { get; set; }
        public string StateCode { get; set; }
    }

    public class TalukaMaster
    {
        [Key]
        public int TalukaId { get; set; }
        public string TalukaName { get; set; }
        public string TalukaCode { get; set; }
        public string DistrictCode { get; set; }
        public string StateCode { get; set; }
    }

    public class VillageMaster
    {
        [Key]
        public int VillageId { get; set; }
        public string VillageName { get; set; }
        public string VillageCode { get; set; }
        public string TalukaCode { get; set; }
        public string DistrictCode { get; set; }
        public string StateCode { get; set; }
    }

    public class BasicHeadMaster
    {
        [Key]
        public int BasicHeadId { get; set; }
       
    }

    public class StandardHeadMaster
    {
        [Key]
        public int StdHeadId { get; set; }

    }

    public class SubHeadMaster
    {
        [Key]
        public int SubHeadId { get; set; }

    }

    public class SectionMaster
    {
        [Key]
        public int SectionId { get; set; }
        public string SectionName { get; set; }

    }

    public class CategoryMaster
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }

    public class SubCategoryMaster
    {
        [Key]
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }

    }


}