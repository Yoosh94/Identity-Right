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
        //Foreign Keys
        public UserOrganisationLinks UserOrganisationLink { get; set; }
        public  int UserOrganisationLinksId { get; set; }
        public UserAddresses UserAddress { get; set; }
        public  int UserAddressesId { get; set; }

        

    }
}
