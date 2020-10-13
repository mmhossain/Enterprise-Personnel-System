namespace ServerApp.Models
{
    public class EmployeeRole
    {
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
