using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace e_Office.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<CategoryMaster> CategoryMasters { get; set; }

        public System.Data.Entity.DbSet<e_Office.Models.AuthorityMaster> AuthorityMasters { get; set; }

        public System.Data.Entity.DbSet<e_Office.Models.ClassificationMaster> ClassificationMasters { get; set; }

        public System.Data.Entity.DbSet<e_Office.Models.DeptMaster> DeptMasters { get; set; }

        public System.Data.Entity.DbSet<e_Office.Models.DesignationMaster> DesignationMasters { get; set; }

        public System.Data.Entity.DbSet<e_Office.Models.DistrictMaster> DistrictMasters { get; set; }

        public System.Data.Entity.DbSet<e_Office.Models.InwardEntry> InwardEntries { get; set; }

        public System.Data.Entity.DbSet<e_Office.Models.SectionMaster> SectionMasters { get; set; }

        public System.Data.Entity.DbSet<e_Office.Models.StandardHeadMaster> StandardHeadMasters { get; set; }

        public System.Data.Entity.DbSet<e_Office.Models.BasicHeadMaster> BasicHeadMasters { get; set; }

        public System.Data.Entity.DbSet<e_Office.Models.StateMaster> StateMasters { get; set; }

        public System.Data.Entity.DbSet<e_Office.Models.SubCategoryMaster> SubCategoryMasters { get; set; }

        public System.Data.Entity.DbSet<e_Office.Models.SubHeadMaster> SubHeadMasters { get; set; }

        public System.Data.Entity.DbSet<e_Office.Models.TalukaMaster> TalukaMasters { get; set; }

        public System.Data.Entity.DbSet<e_Office.Models.UserActivity> UserActivities { get; set; }

        public System.Data.Entity.DbSet<e_Office.Models.UserDetails> UserDetails { get; set; }

        public System.Data.Entity.DbSet<e_Office.Models.UserLogs> UserLogs { get; set; }
    }
}