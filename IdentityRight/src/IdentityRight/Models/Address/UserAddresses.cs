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
        public virtual ICollection<UserAddresses_CustomerOrganisationLinks> UserAddress_UserOrganisationLink { get; set; }
        public AddressType AddressType { get; set; }
        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; set; }

        [ForeignKey("LocationsId")]
        public int LocationsId { get; set; }
    }
}
