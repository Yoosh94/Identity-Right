using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using IdentityRight.Models;

namespace IdentityRight.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IdentityRight.Models.ApplicationOrganisations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("APIKey");

                    b.Property<string>("organisationAddress");

                    b.Property<string>("organisationName");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("IdentityRight.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("IdentityRight.Models.Countries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RegionsId");

                    b.Property<string>("countryName");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("IdentityRight.Models.Locations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountriesId");

                    b.Property<int>("postcode");

                    b.Property<string>("state");

                    b.Property<string>("streetName");

                    b.Property<string>("suburb");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("IdentityRight.Models.Regions", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("regionDescription");

                    b.Property<string>("regionName");

                    b.HasKey("id");
                });

            modelBuilder.Entity("IdentityRight.Models.UserAddresses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressType");

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("LocationsId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("IdentityRight.Models.UserAddresses_CustomerOrganisationLinks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserAddressesId");

                    b.Property<int>("UserOrganisationLinksId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("IdentityRight.Models.UserEmailAddresses", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("EmailType");

                    b.Property<string>("emailAddress");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("IdentityRight.Models.UserEmails_UserOrganisationLinks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserEmailAddressesId");

                    b.Property<int>("UserOrganisationLinksId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("IdentityRight.Models.UserOrganisationLinks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationOrganisationsId");

                    b.Property<string>("ApplicationUserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("IdentityRight.Models.UserPhoneNumbers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("PhoneNumberType");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("IdentityRight.Models.UserPhoneNumbers_CustomerOrganisationLinks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserOrganisationLinksId");

                    b.Property<int>("UserPhoneNumbersId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("IdentityRight.Models.Countries", b =>
                {
                    b.HasOne("IdentityRight.Models.Regions")
                        .WithMany()
                        .HasForeignKey("RegionsId");
                });

            modelBuilder.Entity("IdentityRight.Models.Locations", b =>
                {
                    b.HasOne("IdentityRight.Models.Countries")
                        .WithMany()
                        .HasForeignKey("CountriesId");
                });

            modelBuilder.Entity("IdentityRight.Models.UserAddresses", b =>
                {
                    b.HasOne("IdentityRight.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("IdentityRight.Models.Locations")
                        .WithMany()
                        .HasForeignKey("LocationsId");
                });

            modelBuilder.Entity("IdentityRight.Models.UserAddresses_CustomerOrganisationLinks", b =>
                {
                    b.HasOne("IdentityRight.Models.UserAddresses")
                        .WithMany()
                        .HasForeignKey("UserAddressesId");

                    b.HasOne("IdentityRight.Models.UserOrganisationLinks")
                        .WithMany()
                        .HasForeignKey("UserOrganisationLinksId");
                });

            modelBuilder.Entity("IdentityRight.Models.UserEmailAddresses", b =>
                {
                    b.HasOne("IdentityRight.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("IdentityRight.Models.UserEmails_UserOrganisationLinks", b =>
                {
                    b.HasOne("IdentityRight.Models.UserEmailAddresses")
                        .WithMany()
                        .HasForeignKey("UserEmailAddressesId");

                    b.HasOne("IdentityRight.Models.UserOrganisationLinks")
                        .WithMany()
                        .HasForeignKey("UserOrganisationLinksId");
                });

            modelBuilder.Entity("IdentityRight.Models.UserOrganisationLinks", b =>
                {
                    b.HasOne("IdentityRight.Models.ApplicationOrganisations")
                        .WithMany()
                        .HasForeignKey("ApplicationOrganisationsId");

                    b.HasOne("IdentityRight.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("IdentityRight.Models.UserPhoneNumbers", b =>
                {
                    b.HasOne("IdentityRight.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("IdentityRight.Models.UserPhoneNumbers_CustomerOrganisationLinks", b =>
                {
                    b.HasOne("IdentityRight.Models.UserOrganisationLinks")
                        .WithMany()
                        .HasForeignKey("UserOrganisationLinksId");

                    b.HasOne("IdentityRight.Models.UserPhoneNumbers")
                        .WithMany()
                        .HasForeignKey("UserPhoneNumbersId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("IdentityRight.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("IdentityRight.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("IdentityRight.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
