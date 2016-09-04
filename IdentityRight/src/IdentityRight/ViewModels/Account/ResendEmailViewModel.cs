using System.ComponentModel.DataAnnotations;

namespace IdentityRight.ViewModels.Account
{
    public class ResendEmailViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
