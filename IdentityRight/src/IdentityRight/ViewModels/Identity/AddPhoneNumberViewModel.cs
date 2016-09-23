using System.ComponentModel.DataAnnotations;
using IdentityRight.Models;
using System.Collections.Generic;

namespace IdentityRight.ViewModels.Identity
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        public Models.PhoneNumberTypes NumberType { get; set; }

        public string NumberTypeString { get; set; }

        public List<UserPhoneNumbers> WorkNumbers { get; set; }
        public List<UserPhoneNumbers> MobileNumbers { get; set; }
        public List<UserPhoneNumbers> BusinessNumbers { get; set; }
        public List<UserPhoneNumbers> HomeNumbers { get; set; }

    }
}
