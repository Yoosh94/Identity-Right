using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace IdentityRight.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //One User can have many CustomerOrganisation Links
        public virtual ICollection<UserOrganisationLinks> CustomerOrganisationLinks { get; set; }
        //One User can have many phone numbers
        public virtual ICollection<UserPhoneNumbers> UserPhoneNumber { get; set; }
        //One User can have many email addresses
        public virtual ICollection<UserEmailAddresses> UserEmailAddress { get; set; }
        //One user can have many addresses
        public virtual ICollection<UserAddresses> UserAddress { get; set; }

        public bool isAccountCompleted { get; set; }
        [Key]
        public int IRID { get; set; }
    }
}
