using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRight.Models
{
    public class BranchDepartmentConnection
    {
        public int Id { get; set; }
        public Departments Department { get; set; }
        public int DepartmentsId { get; set; }
        public Branches Branch { get; set; }
        public int BranchesId { get; set; }
    }
}
