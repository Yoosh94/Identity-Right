using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityRight.Models
{
    public class Locations
    {
        public int Id { get; set; }
        [Display(Name = "State")]
        public string state { get; set; }
        [Display(Name = "Street name")]
        public string streetName { get; set; }
        [Display(Name = "Street number")]
        public string streetNumber { get; set; }
        [Display(Name = "Unit number")]
        public string unitNumber { get; set; }
        [Display(Name = "Postcode")]
        public int postcode { get; set; }
        [Display(Name = "Suburb")]
        public string suburb { get; set; }   
        public List<UserAddresses> UserAddresses { get; set; }
        //Foreign Key
        public Countries Countries { get; set; }
        public int CountriesId { get; set; }
    }
}
