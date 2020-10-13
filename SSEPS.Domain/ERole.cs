using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSEPS.Domain
{
    public class ERole 
    {
        [Key]
        public int ERoleId { get; set; }

        public string Name { get; set; }

        public IList<EmployeeRole> EmployeeRoles { get; set; }
    }
}
