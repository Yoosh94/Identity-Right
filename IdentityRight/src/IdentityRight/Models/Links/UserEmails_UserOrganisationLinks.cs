using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Models
{
    public class UserEmails_UserOrganisationLinks
    {
        public int Id { get; set; }
        [ForeignKey("UserOrganisationLinksId")]
        public int UserOrganisationLinksId { get; set; }
        [ForeignKey("UserEmailAddressesId")]
        public int UserEmailAddressesId { get; set; }


    }
}
