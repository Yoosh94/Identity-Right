using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace IdentityRight.Migrations
{
    public partial class addAnotherPrimaryKeyToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Countries_Regions_RegionsId", table: "Countries");
            migrationBuilder.DropForeignKey(name: "FK_Locations_Countries_CountriesId", table: "Locations");
            migrationBuilder.DropForeignKey(name: "FK_UserAddresses_Locations_LocationsId", table: "UserAddresses");
            migrationBuilder.DropForeignKey(name: "FK_UserAddresses_CustomerOrganisationLinks_UserAddresses_UserAddressesId", table: "UserAddresses_CustomerOrganisationLinks");
            migrationBuilder.DropForeignKey(name: "FK_UserAddresses_CustomerOrganisationLinks_UserOrganisationLinks_UserOrganisationLinksId", table: "UserAddresses_CustomerOrganisationLinks");
            migrationBuilder.DropForeignKey(name: "FK_UserEmails_UserOrganisationLinks_UserEmailAddresses_UserEmailAddressesId", table: "UserEmails_UserOrganisationLinks");
            migrationBuilder.DropForeignKey(name: "FK_UserEmails_UserOrganisationLinks_UserOrganisationLinks_UserOrganisationLinksId", table: "UserEmails_UserOrganisationLinks");
            migrationBuilder.DropForeignKey(name: "FK_UserOrganisationLinks_ApplicationOrganisations_ApplicationOrganisationsId", table: "UserOrganisationLinks");
            migrationBuilder.DropForeignKey(name: "FK_UserPhoneNumbers_CustomerOrganisationLinks_UserOrganisationLinks_UserOrganisationLinksId", table: "UserPhoneNumbers_CustomerOrganisationLinks");
            migrationBuilder.DropForeignKey(name: "FK_UserPhoneNumbers_CustomerOrganisationLinks_UserPhoneNumbers_UserPhoneNumbersId", table: "UserPhoneNumbers_CustomerOrganisationLinks");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.AddUniqueConstraint(
                name: "AK_ApplicationUser_IRID",
                table: "AspNetUsers",
                column: "IRID");
            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Regions_RegionsId",
                table: "Countries",
                column: "RegionsId",
                principalTable: "Regions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Countries_CountriesId",
                table: "Locations",
                column: "CountriesId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_Locations_LocationsId",
                table: "UserAddresses",
                column: "LocationsId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_CustomerOrganisationLinks_UserAddresses_UserAddressesId",
                table: "UserAddresses_CustomerOrganisationLinks",
                column: "UserAddressesId",
                principalTable: "UserAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_CustomerOrganisationLinks_UserOrganisationLinks_UserOrganisationLinksId",
                table: "UserAddresses_CustomerOrganisationLinks",
                column: "UserOrganisationLinksId",
                principalTable: "UserOrganisationLinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_UserEmails_UserOrganisationLinks_UserEmailAddresses_UserEmailAddressesId",
                table: "UserEmails_UserOrganisationLinks",
                column: "UserEmailAddressesId",
                principalTable: "UserEmailAddresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_UserEmails_UserOrganisationLinks_UserOrganisationLinks_UserOrganisationLinksId",
                table: "UserEmails_UserOrganisationLinks",
                column: "UserOrganisationLinksId",
                principalTable: "UserOrganisationLinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_UserOrganisationLinks_ApplicationOrganisations_ApplicationOrganisationsId",
                table: "UserOrganisationLinks",
                column: "ApplicationOrganisationsId",
                principalTable: "ApplicationOrganisations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_UserPhoneNumbers_CustomerOrganisationLinks_UserOrganisationLinks_UserOrganisationLinksId",
                table: "UserPhoneNumbers_CustomerOrganisationLinks",
                column: "UserOrganisationLinksId",
                principalTable: "UserOrganisationLinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_UserPhoneNumbers_CustomerOrganisationLinks_UserPhoneNumbers_UserPhoneNumbersId",
                table: "UserPhoneNumbers_CustomerOrganisationLinks",
                column: "UserPhoneNumbersId",
                principalTable: "UserPhoneNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Countries_Regions_RegionsId", table: "Countries");
            migrationBuilder.DropForeignKey(name: "FK_Locations_Countries_CountriesId", table: "Locations");
            migrationBuilder.DropForeignKey(name: "FK_UserAddresses_Locations_LocationsId", table: "UserAddresses");
            migrationBuilder.DropForeignKey(name: "FK_UserAddresses_CustomerOrganisationLinks_UserAddresses_UserAddressesId", table: "UserAddresses_CustomerOrganisationLinks");
            migrationBuilder.DropForeignKey(name: "FK_UserAddresses_CustomerOrganisationLinks_UserOrganisationLinks_UserOrganisationLinksId", table: "UserAddresses_CustomerOrganisationLinks");
            migrationBuilder.DropForeignKey(name: "FK_UserEmails_UserOrganisationLinks_UserEmailAddresses_UserEmailAddressesId", table: "UserEmails_UserOrganisationLinks");
            migrationBuilder.DropForeignKey(name: "FK_UserEmails_UserOrganisationLinks_UserOrganisationLinks_UserOrganisationLinksId", table: "UserEmails_UserOrganisationLinks");
            migrationBuilder.DropForeignKey(name: "FK_UserOrganisationLinks_ApplicationOrganisations_ApplicationOrganisationsId", table: "UserOrganisationLinks");
            migrationBuilder.DropForeignKey(name: "FK_UserPhoneNumbers_CustomerOrganisationLinks_UserOrganisationLinks_UserOrganisationLinksId", table: "UserPhoneNumbers_CustomerOrganisationLinks");
            migrationBuilder.DropForeignKey(name: "FK_UserPhoneNumbers_CustomerOrganisationLinks_UserPhoneNumbers_UserPhoneNumbersId", table: "UserPhoneNumbers_CustomerOrganisationLinks");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropUniqueConstraint(name: "AK_ApplicationUser_IRID", table: "AspNetUsers");
            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Regions_RegionsId",
                table: "Countries",
                column: "RegionsId",
                principalTable: "Regions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Countries_CountriesId",
                table: "Locations",
                column: "CountriesId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_Locations_LocationsId",
                table: "UserAddresses",
                column: "LocationsId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_CustomerOrganisationLinks_UserAddresses_UserAddressesId",
                table: "UserAddresses_CustomerOrganisationLinks",
                column: "UserAddressesId",
                principalTable: "UserAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_CustomerOrganisationLinks_UserOrganisationLinks_UserOrganisationLinksId",
                table: "UserAddresses_CustomerOrganisationLinks",
                column: "UserOrganisationLinksId",
                principalTable: "UserOrganisationLinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_UserEmails_UserOrganisationLinks_UserEmailAddresses_UserEmailAddressesId",
                table: "UserEmails_UserOrganisationLinks",
                column: "UserEmailAddressesId",
                principalTable: "UserEmailAddresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_UserEmails_UserOrganisationLinks_UserOrganisationLinks_UserOrganisationLinksId",
                table: "UserEmails_UserOrganisationLinks",
                column: "UserOrganisationLinksId",
                principalTable: "UserOrganisationLinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_UserOrganisationLinks_ApplicationOrganisations_ApplicationOrganisationsId",
                table: "UserOrganisationLinks",
                column: "ApplicationOrganisationsId",
                principalTable: "ApplicationOrganisations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_UserPhoneNumbers_CustomerOrganisationLinks_UserOrganisationLinks_UserOrganisationLinksId",
                table: "UserPhoneNumbers_CustomerOrganisationLinks",
                column: "UserOrganisationLinksId",
                principalTable: "UserOrganisationLinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_UserPhoneNumbers_CustomerOrganisationLinks_UserPhoneNumbers_UserPhoneNumbersId",
                table: "UserPhoneNumbers_CustomerOrganisationLinks",
                column: "UserPhoneNumbersId",
                principalTable: "UserPhoneNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
