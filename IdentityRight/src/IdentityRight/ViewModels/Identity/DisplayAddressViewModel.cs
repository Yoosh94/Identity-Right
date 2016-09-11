using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityRight.Models;
using IdentityRight.Services;

namespace IdentityRight.ViewModels.Identity
{
    public class DisplayAddressViewModel
    {
        public List<UserAddresses> userAddress { get; }
        public List<Locations> location { get; }

        public DisplayAddressViewModel()
        {
            userAddress = new List<UserAddresses>();
            location = new List<Locations>();
        }
    }
}
