using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Models
{
    public class Locations
    {
        public int Id { get; set; }
        public string state { get; set; }
        public string streetName { get; set; }
        public int postcode { get; set; } 
        public string suburb { get; set; }   
        public virtual ICollection<UserAddresses> UserAddresses { get; set; }

        [ForeignKey("CountriesId")]
        public int CountriesId { get; set; }
    }
}
