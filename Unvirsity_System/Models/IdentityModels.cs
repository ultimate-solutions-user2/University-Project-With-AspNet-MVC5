using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Unvirsity_System.Models
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
            : base(@"Data Source=.;Initial Catalog=UniversityDept;Integrated Security=true")
        {
        }
         
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Faculty> Faculities { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Professor> Professors { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<Submit_Student> Submit_Students { get; set; }
        public virtual DbSet<Branch>Branches { get; set; }
        public virtual DbSet<Location>Locations { get; set; }
        //public object Submit_Student { get; internal set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}