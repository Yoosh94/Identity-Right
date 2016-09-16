using IdentityRight.Models;
using System.ComponentModel.DataAnnotations;
using System;

namespace IdentityRight.ViewModels.Identity
{
    public class AddAddressViewModel
    {
        [Required]
        [Display(Name = "Address Type")]
        public AddressType addressType { get; set; }

        [Display(Name = "Unit")]
        public string unitNumber { get; set; }

        [Key]
        [Display(Name = "Street Number")]
        public string streetNumber { get; set; }

        [Display(Name ="Street Address")]
        public string streetName { get; set; }

        [Display(Name ="City")]
        public string suburb { get; set; }

        [Display(Name ="State")]
        public string state { get; set; }

        [Display(Name ="Postcode")]
        public string postcode { get; set; }

        [Display(Name ="Country")]
        public string countryName { get; set; }

        [Display(Name = "Start Date")]
        public DateTime startDate { get; set; }

        [Display(Name = "End date")]
        public DateTime endDate { get; set; }

    }
}
