using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityRight.Models
{
    public class Countries
    {
        public int Id { get; set; }
        public List<Locations> Locations { get; set; }
        [Display(Name = "Country")]
        public string countryName { get; set; }
        //Foreign Keys
        public Regions Region { get; set; }
        [Display(Name = "Region")]
        public int RegionsId { get; set; }
    }
}
