using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Models
{
    public class Countries
    {
        public int Id { get; set; }
        public virtual ICollection<Locations> Location { get; set; }
        public string countryName { get; set; }
        [ForeignKey("RegionsId")]
        public int RegionsId { get; set; }
    }
}
