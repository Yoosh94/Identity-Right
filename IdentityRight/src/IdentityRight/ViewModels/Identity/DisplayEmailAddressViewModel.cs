using IdentityRight.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.ViewModels.Identity
{
    public class DisplayEmailAddressViewModel
    {
        public List<UserEmailAddresses> emailAddresses { get; set; }
        public DisplayEmailAddressViewModel()
        {
            emailAddresses = new List<UserEmailAddresses>();
        }
    }
}
