using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityRight.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //One User can have many CustomerOrganisation Links
        public ICollection<UserOrganisationLinks> CustomerOrganisationLinks { get; set; }
        //One User can have many phone numbers
        public ICollection<UserPhoneNumbers> UserPhoneNumber { get; set; }
    }
}
