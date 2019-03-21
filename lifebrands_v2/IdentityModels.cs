using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using lifebrands_v2.Entities;
using System.Collections.Generic;

namespace IdentityMySQLDemo.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser
    // class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }
    [DbConfigurationType("MySql.Data.Entity.MySqlEFConfiguration, MySql.Data.Entity.EF6")]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        static ApplicationDbContext()
        {
            Database.SetInitializer(new MySqlInitializer());
        }

        public ApplicationDbContext()
          : base("DefaultConnection")
        {
        }

        public IEnumerable<object> products { get; internal set; }
    }

}
