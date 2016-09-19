using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityRight.Models;
using Microsoft.AspNet.Mvc;

namespace IdentityRight.ViewModels.UpdateDetails
{
    public class UpdateAddressViewModel
    {
        public Locations location { get; set; }
        public UserAddresses userAddress { get; set; }
        public string countryName { get; set; }
        [HiddenInput]
        public int userAddressID { get; set; }
    }
}
