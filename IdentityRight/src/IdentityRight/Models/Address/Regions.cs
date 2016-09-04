using System.Collections.Generic;

namespace IdentityRight.Models
{
    public class Regions
    {
        public int id { get; set; }
        public string regionName { get; set; }
        public string regionDescription { get; set; }
        public List<Countries> Country { get; set; }
        
    }
}
