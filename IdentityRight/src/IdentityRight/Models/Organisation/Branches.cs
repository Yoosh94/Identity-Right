using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Models
{
    public class Branches
    {
        public int Id { get; set; }
        public string Description { get; set; }  
           
        public ApplicationOrganisations ApplicationOrganisations { get; set; }
        public int ApplicationOrganisationsId { get; set; }

        public Locations Locations { get; set; }
        public int LocationsId { get; set; }
    }
}
