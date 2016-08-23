using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Models
{
    public class UserAddresses
    {
        public int Id { get; set; }
        public List<UserAddresses_CustomerOrganisationLinks> UserAddress_UserOrganisationLink { get; set; }
        public AddressType AddressType { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        //Foreign Key
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public Locations Location { get; set; }
        public int LocationsId { get; set; }
    }
}
