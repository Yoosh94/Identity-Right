﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Models
{
    public class UserOrganisationLinks
    {
        public int Id { get; set; }
        public ICollection<UserPhoneNumbers_CustomerOrganisationLinks> PhoneNumber_CustomerOrganisationLinks { get; set; }
    }
}
