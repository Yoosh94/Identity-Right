using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityRight.Models;

namespace IdentityRight.ViewModels.Identity
{
    public class LinkAddressToOrganisationViewModel
    {
        public List<ApplicationOrganisations> LinkedOrganisation { get; set; }
        public List<ApplicationOrganisations> UnlinkedOrganisation { get; set; }
    }
}
