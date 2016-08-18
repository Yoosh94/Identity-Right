using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Models
{
    public class UserEmailAddresses
    {
        public int ID { get; set; }
        public string emailAddress { get; set; }
        public EmailTypes EmailType { get; set; }
        public virtual ICollection<UserEmails_UserOrganisationLinks> UserEmail_UserOrganisationLink { get; set; }
        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; set; }
    }
}
