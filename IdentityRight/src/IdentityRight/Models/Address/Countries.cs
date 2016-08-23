using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
