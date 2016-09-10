using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityRight.Models;

namespace IdentityRight.ViewModels.Identity
{
    public class OrganisationsViewModel
    {
        //public string organisationName { get; set; }
        public List<ApplicationOrganisations> LinkedOrgs { get; set; }
        public List<ApplicationOrganisations> UnlinkedOrgs { get; set; }
    }
}
