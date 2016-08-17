using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Models
{
    public class UserEmailAddresses
    {
        public int ID { get; set; }
        public string emailAddress { get; set; }
        public EmailTypes EmailType { get; set; }
        public ICollection<UserEmails_UserOrganisationLinks> UserEmail_UserOrganisationLink { get; set; }
    }
}
