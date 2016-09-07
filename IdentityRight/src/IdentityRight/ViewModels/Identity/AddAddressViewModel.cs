using IdentityRight.Models;
using System.ComponentModel.DataAnnotations;

namespace IdentityRight.ViewModels.Identity
{
    public class AddAddressViewModel
    {
        [Required]
        [Display(Name = "Address Type")]
        public AddressType addressType { get; set; }

        [Display(Name = "Unit")]
        public string subpremise { get; set; }

        [Key]
        [Display(Name = "Street Number")]
        public string street_number { get; set; }

        [Display(Name ="Street Address")]
        public string route { get; set; }

        [Display(Name ="City")]
        public string locality { get; set; }

        [Display(Name ="State")]
        public string administrative_area_level_1 { get; set; }

        [Display(Name ="Postcode")]
        public string postal_code { get; set; }

        [Display(Name ="Country")]
        public string country { get; set; }

    }
}
