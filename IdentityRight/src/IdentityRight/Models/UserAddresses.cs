using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Models
{
    public class UserAddresses
    {
        public int Id { get; set; }
        public ICollection<UserAddresses_CustomerOrganisationLinks> UserAddress_UserOrganisationLink { get; set; }
    }
}
