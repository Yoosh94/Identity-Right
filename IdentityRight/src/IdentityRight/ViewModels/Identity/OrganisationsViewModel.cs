using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityRight.Models;
using Microsoft.AspNet.Mvc.Rendering;

namespace IdentityRight.ViewModels.Identity
{
    public class OrganisationsViewModel
    {
        //public string organisationName { get; set; }
        //public List<ApplicationOrganisations> LinkedOrgs { get; set; }
        public List<ApplicationOrganisations> UnlinkedOrgs { get; set; }

        public List<SelectListItem> LinkedOrgs { get; set; }
        //public List<SelectListItem> UnlinkedOrgs { get; set; }

        public List<long> ReturnedIDs{ get; set; }
    }
}
