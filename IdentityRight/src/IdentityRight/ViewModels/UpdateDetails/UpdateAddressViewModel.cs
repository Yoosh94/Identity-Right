using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityRight.Models;

namespace IdentityRight.ViewModels.EditDetails
{
    public class UpdateAddressViewModel
    {
        public Locations location { get; set; }
        public UserAddresses userAddress { get; set; }
    }
}
