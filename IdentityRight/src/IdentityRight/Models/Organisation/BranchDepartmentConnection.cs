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
