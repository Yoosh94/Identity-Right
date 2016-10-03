using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityRight.Models
{
    public class ApplicationOrganisations
    {
        public int Id { get; set; }
        public string organisationName { get; set; }
        public string organisationAddress { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public List<UserOrganisationLinks> CustomerOrganisationLinks { get; set; }
        public Guid APIKey { get; set; }
    }
}
