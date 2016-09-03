using System.Collections.Generic;


namespace IdentityRight.Models
{
    public class UserOrganisationLinks
    {
        public int Id { get; set; }
        public List<UserPhoneNumbers_CustomerOrganisationLinks> PhoneNumber_CustomerOrganisationLinks { get; set; }
        public List<UserEmails_UserOrganisationLinks> UserEmail_UserOrganisaionLink { get; set; }
        public List<UserAddresses_CustomerOrganisationLinks> UserAddress_UserOrganisationLink { get; set; }
        //Foreign Keys
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationOrganisations ApplicationOrganisation { get; set; }
        public int ApplicationOrganisationsId { get; set; }


        
    }
}
