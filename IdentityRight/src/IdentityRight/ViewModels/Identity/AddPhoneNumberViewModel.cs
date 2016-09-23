using System.ComponentModel.DataAnnotations;

namespace IdentityRight.ViewModels.Identity
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        public IdentityRight.Models.PhoneNumberTypes NumberType { get; set; }

    }
}
