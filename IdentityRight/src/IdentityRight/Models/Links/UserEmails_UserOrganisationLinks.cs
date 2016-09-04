namespace IdentityRight.Models
{
    public class UserEmails_UserOrganisationLinks
    {
        public int Id { get; set; }
        //Foreign Key
        public UserOrganisationLinks UserOrganisationLink { get; set; }
        public int UserOrganisationLinksId { get; set; }
        public UserEmailAddresses UserEmailAddress { get; set; }
        public int UserEmailAddressesId { get; set; }


    }
}
