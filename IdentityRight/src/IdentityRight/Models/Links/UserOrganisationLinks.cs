using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Models
{
    public class UserOrganisationLinks
    {
        public int Id { get; set; }
        public ICollection<UserPhoneNumbers_CustomerOrganisationLinks> PhoneNumber_CustomerOrganisationLinks { get; set; }
        public ICollection<UserEmails_UserOrganisationLinks> UserEmail_UserOrganisaionLink { get; set; }
        public ICollection<UserAddresses_CustomerOrganisationLinks> UserAddress_UserOrganisationLink { get; set; }
    }
}
