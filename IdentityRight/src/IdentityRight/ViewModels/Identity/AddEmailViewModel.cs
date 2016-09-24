using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityRight.Models;
using System.ComponentModel.DataAnnotations;

namespace IdentityRight.ViewModels.Identity
{
    public class AddEmailViewModel
    {
        [EmailAddress]
        [Display(Name = "Email address")]
        public string email { get; set; }
        [Display(Name = "Email Type")]
        public EmailTypes emailTypes { get; set; }
    }
}
