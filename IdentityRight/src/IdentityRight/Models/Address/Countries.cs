using System.Collections.Generic;

namespace IdentityRight.Models
{
    public class Countries
    {
        public int Id { get; set; }
        public List<Locations> Locations { get; set; }
        public string countryName { get; set; }
        //Foreign Keys
        public Regions Region { get; set; }
        public int RegionsId { get; set; }
    }
}
