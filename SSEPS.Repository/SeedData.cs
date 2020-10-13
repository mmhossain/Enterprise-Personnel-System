using Microsoft.EntityFrameworkCore;
using SSEPS.Domain;
using System.Linq;

namespace SSEPS.Repository
{
    public class SeedData {

        public static void SeedDatabase(EmployeeDataContext context)
        {
            context.Database.Migrate();

            if (context.Employees.Count() == 0)
            {
                context.Employees.AddRange(
                    new Employee { EmployeeId = "SSEPS-00001", FirstName = "Jeffrey", LastName = "Wells" },
                    new Employee { EmployeeId = "SSEPS-00002", FirstName = "Victor", LastName = "Atkins" },
                    new Employee { EmployeeId = "SSEPS-00003", FirstName = "Kelli", LastName = "Hamilton" },
                    new Employee { EmployeeId = "SSEPS-00004", FirstName = "Adam", LastName = "Braun" },
                    new Employee { EmployeeId = "SSEPS-00005", FirstName = "Lois", LastName = "Martinez" });
            }

            //if (context.ERoles.Count() == 0)
            //{
            //    context.ERoles.AddRange(
            //        new ERole { ERoleId = 1, Name = "Director" },
            //        new ERole { ERoleId = 2, Name = "IT, Support" },
            //        new ERole { ERoleId = 3, Name = "Support" },
            //        new ERole { ERoleId = 4, Name = "Accounting" },
            //        new ERole { ERoleId = 5, Name = "Analyst" },
            //        new ERole { ERoleId = 5, Name = "Analyst, Sales" },
            //        new ERole { ERoleId = 5, Name = "IT, Sales" });
            //}

            context.SaveChanges();
        }
    }
}
