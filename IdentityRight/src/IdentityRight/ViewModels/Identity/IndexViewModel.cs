using System.Collections.Generic;
using IdentityRight.Models;
using Microsoft.AspNet.Identity;

namespace IdentityRight.ViewModels.Identity
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }

        public IList<UserLoginInfo> Logins { get; set; }

        public string PhoneNumber { get; set; }

        public bool TwoFactor { get; set; }

        public bool BrowserRemembered { get; set; }

        public List<ApplicationOrganisations> Organisations { get; set; }
    }
}
