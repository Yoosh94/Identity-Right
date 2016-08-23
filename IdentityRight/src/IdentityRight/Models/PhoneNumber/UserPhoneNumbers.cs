using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Models
{
    public class UserPhoneNumbers
    {
        public int Id { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public PhoneNumberTypes PhoneNumberType { get; set; }
        public List<UserPhoneNumbers_CustomerOrganisationLinks> PhoneNumber_CustomerOrganisationLink { get; set; }
        //Foreign Key
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
