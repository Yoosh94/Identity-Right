using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityRight.Models;
using System.ComponentModel.DataAnnotations;

namespace IdentityRight.ViewModels.Identity
{
    public class DisplayAddressesViewModel
    {
        public AddressType addressType { get; }
        [Key]
        public Locations loc { get; }
        //public string unitNumber { get; }
        //public string streetNumber { get; }
        //public string streetName { get; }
        //public string suburb { get; }
        //public string postcode { get; }
        //public string state { get; }
        //public string country { get; }
    }
}
