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
        public virtual PhoneNumberTypes PhoneNumberType { get; set; }
        public virtual ICollection<UserPhoneNumbers_CustomerOrganisationLinks> PhoneNumber_CustomerOrganisationLink { get; set; }
        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; set; }
    }
}
