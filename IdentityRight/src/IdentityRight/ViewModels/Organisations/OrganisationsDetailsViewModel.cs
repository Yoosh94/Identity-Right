using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IdentityRight.Models;

namespace IdentityRight.ViewModels.Organisations
{
    public class OrganisationDetailsViewModel
    {
        [Display(Name = "Organisation Name")]
        public string OrganisationName { get; set; }

        [Display(Name = "Organisation Address")]
        public string OrganisationAddress { get; set; }

        public List<ApplicationUser> LinkedUsers { get; set; }
    }

    public class OrganisationsViewModel
    {
        public List<ApplicationOrganisations> Organisations { get; set; }
    }
}
