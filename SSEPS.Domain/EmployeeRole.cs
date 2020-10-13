namespace SSEPS.Domain
{
    public class EmployeeRole
    {
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int ERoleId { get; set; }
        public ERole ERole { get; set; }
    }
}
