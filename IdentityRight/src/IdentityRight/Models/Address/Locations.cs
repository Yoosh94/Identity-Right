using System.Collections.Generic;

namespace IdentityRight.Models
{
    public class Locations
    {
        public int Id { get; set; }
        public string state { get; set; }
        public string streetName { get; set; }
        public string streetNumber { get; set; }
        public string unitNumber { get; set; }
        public int postcode { get; set; } 
        public string suburb { get; set; }   
        public List<UserAddresses> UserAddresses { get; set; }
        //Foreign Key
        public Countries Countries { get; set; }
        public int CountriesId { get; set; }
    }
}
