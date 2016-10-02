using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityRight.Models;
using Microsoft.AspNet.Mvc.Rendering;

namespace IdentityRight.ViewModels.Identity
{
    public class LinkAddressToOrganisationViewModel
    {
        public List<ApplicationOrganisations> LinkedOrganisation { get; set; }
        public List<ApplicationOrganisations> UnlinkedOrganisation { get; set; }
        public IEnumerable<SelectListItem> LinkedOrgs { get; set; }
        public IEnumerable<SelectListItem> UnlinkedOrgs { get; set; }
        public int UserAddressID { get; set; }
        public List<int> ReturnedIDs { get; set; }
    }
}
