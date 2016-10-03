using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using IdentityRight.ViewModels.Identity;
using Microsoft.Data.Entity.Infrastructure;

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
        public DbSet<Branches> Branch { get; set; }
        public DbSet<Departments> Department { get; set; }
        public DbSet<BranchDepartmentConnection> BranchDepartmentConnection { get; set; }
        public DbSet<AddAddressViewModel> AddAddressViewModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //Uncomment options.useInMemoryDatabase() to run unit tests.
            //options.UseInMemoryDatabase();
            //Uncomment UseSqlServer to run normally.
            options.UseSqlServer(@"Server=tcp:sit302db.database.windows.net,1433;Initial Catalog=IRDB;Persist Security Info=False;User ID=sit302;Password=IdentityRightP@ssword;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //This allows the property IRID to be set as an IDENTITY type so we can auto increment the value.
            //builder.Entity<ApplicationUser>().Property<long>(nameof(ApplicationUser.IRID)).UseSqlServerIdentityColumn();
                
        }

        private void s()
        {

        }

        
    }
}
