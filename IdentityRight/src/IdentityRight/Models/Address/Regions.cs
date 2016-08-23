using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
