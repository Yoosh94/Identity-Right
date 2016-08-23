using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Models
{
    public class UserPhoneNumbers_CustomerOrganisationLinks
    {
        public int Id { get; set; }
        //Foreign Key
        public UserPhoneNumbers UserPhoneNumber { get; set; }
        public int UserPhoneNumbersId { get; set; }
        public UserOrganisationLinks UserOrganisationLink { get; set; }
        public int UserOrganisationLinksId { get; set; }
    }
}
