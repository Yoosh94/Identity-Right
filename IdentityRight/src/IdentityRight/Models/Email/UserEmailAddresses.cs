using System.Collections.Generic;

namespace IdentityRight.Models
{
    public class UserEmailAddresses
    {
        public int ID { get; set; }
        public string emailAddress { get; set; }
        public EmailTypes EmailType { get; set; }
        public List<UserEmails_UserOrganisationLinks> UserEmail_UserOrganisationLink { get; set; }
        //Foreign Key
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public bool Confirmed { get; set; }
    }
}
