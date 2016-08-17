using System;
using System.Collections.Generic;
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
        public ICollection<UserAddresses> UserAddress { get; set; }

    }
}
