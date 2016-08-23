using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Models
{
    public class Departments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int planLevel { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        public List<BranchDepartmentConnection> BranchDepartmentConnection { get; set; }
    }
}
