using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;


namespace IdentityRight.Models
{
    public class ApplicationOrganisations
    {
        public int Id { get; set; }
        public string organisationName { get; set; }
        public string organisationAddress { get; set; }
        public ICollection<UserOrganisationLinks> CustomerOrganisationLinks { get; set; }
        public Guid APIKey { get; set; }
    }
}
