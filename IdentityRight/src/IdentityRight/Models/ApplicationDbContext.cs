using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace IdentityRight.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //The following DbSets are used as contexts to query the database.
        //These are also needed here for the Entity Framework to convert classes to tables.
        public DbSet<ApplicationOrganisations> ApplicationOrganisations { get; set; }
        public DbSet<UserOrganisationLinks> UserOrganisationLinks { get; set; }
        public DbSet<UserPhoneNumbers> UsersPhoneNumbers { get; set; }
        public DbSet<UserPhoneNumbers_CustomerOrganisationLinks> PhoneNumber_CustomerOrganisationLink { get; set; }
        public DbSet<UserEmailAddresses> UserEmailAddress { get; set; }
        public DbSet<UserEmails_UserOrganisationLinks> UserEmail_UserOrganisationLink { get; set; }
        public DbSet<UserAddresses> UserAddress { get; set; }
        public DbSet<UserAddresses_CustomerOrganisationLinks> UserAddress_UserOrganisationLink { get; set; }
        public DbSet<Locations> Location { get; set; }
        public DbSet<Countries> Country { get; set; }
        public DbSet<Regions>Region { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //This allows the property IRID to be set as an IDENTITY type so we can auto increment the value.
            builder.Entity<ApplicationUser>().Property<long>(nameof(ApplicationUser.IRID)).UseSqlServerIdentityColumn();
                
        }
    }
}
