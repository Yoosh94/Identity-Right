using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Models
{
    public class UserPhoneNumbers
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public virtual PhoneNumberTypes PhoneNumberType { get; set; }
        public ICollection<UserPhoneNumbers_CustomerOrganisationLinks> PhoneNumber_CustomerOrganisationLink { get; set; }
    }
}
