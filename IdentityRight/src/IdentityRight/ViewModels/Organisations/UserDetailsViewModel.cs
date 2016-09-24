using System.Collections.Generic;
using IdentityRight.Models;

namespace IdentityRight.ViewModels.Organisations
{
    public class UserDetailsViewModel
    {
        public ApplicationUser User { get; set; }
        public List<UserPhoneNumbers> UserPhoneNumbers { get; set; }
        public List<UserAddresses> AddressIds { get; set; }
        public List<Locations> UserAddresses { get; set; }
        public List<UserEmailAddresses> UserEmails { get; set; }
    }
}
