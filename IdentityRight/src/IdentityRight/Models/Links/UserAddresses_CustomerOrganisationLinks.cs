using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Models
{
    public class UserAddresses_CustomerOrganisationLinks
    {
        public int Id { get; set; }
        [ForeignKey("UserOrganistionlinkId")]
        public  int UserOrganisationLinksId { get; set; }
        //public virtual UserOrganisationLinks userOrganisationLink { get; set; }
        [ForeignKey("UserAddressId")]
        public  int UserAddressesId { get; set; }
        //public virtual UserAddresses UserAddress { get; set; }

        

    }
}
