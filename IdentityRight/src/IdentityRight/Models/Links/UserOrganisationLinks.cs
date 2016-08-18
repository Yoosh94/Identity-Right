using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace IdentityRight.Models
{
    public class UserOrganisationLinks
    {
        public int Id { get; set; }
        public virtual ICollection<UserPhoneNumbers_CustomerOrganisationLinks> PhoneNumber_CustomerOrganisationLinks { get; set; }
        public virtual ICollection<UserEmails_UserOrganisationLinks> UserEmail_UserOrganisaionLink { get; set; }
        public virtual ICollection<UserAddresses_CustomerOrganisationLinks> UserAddress_UserOrganisationLink { get; set; }
        [ForeignKey("UserID")]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationOrganisationsId")]
        public int ApplicationOrganisationsId { get; set; }


        
    }
}
