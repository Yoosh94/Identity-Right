﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Models
{
    public class UserPhoneNumbers_CustomerOrganisationLinks
    {
        public int Id { get; set; }
        [ForeignKey("UserPhoneNumbersId")]
        public int UserPhoneNumbersId { get; set; }
        [ForeignKey("UserOrganisationLinksId")]
        public int UserOrganisationLinksId { get; set; }
    }
}
