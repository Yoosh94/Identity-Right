using System.Collections.Generic;

namespace IdentityRight.Models
{
    public class Branches
    {
        public int Id { get; set; }
        public string Description { get; set; }  
        public List<BranchDepartmentConnection>BranchDepartmentConnection { get; set; }
        //Foreign Keys   
        public ApplicationOrganisations ApplicationOrganisations { get; set; }
        public int ApplicationOrganisationsId { get; set; }
        public Locations Locations { get; set; }
        public int LocationsId { get; set; }
    }
}
