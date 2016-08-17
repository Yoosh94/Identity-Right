using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Models
{
    public class Countries
    {
        public int Id { get; set; }
        public ICollection<Locations> Location { get; set; }
        public string countryName { get; set; }
    }
}
