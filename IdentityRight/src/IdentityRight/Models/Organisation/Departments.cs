using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
