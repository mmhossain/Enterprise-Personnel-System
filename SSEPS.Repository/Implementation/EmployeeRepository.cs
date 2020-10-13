using Microsoft.EntityFrameworkCore;
using SSEPS.Domain;
using System.Collections.Generic;
using System.Linq;

namespace SSEPS.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeDataContext context;

        public EmployeeRepository(EmployeeDataContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Employee> GetEmployees(string managerId = "")
        {
            IQueryable<Employee> query = context.Employees.Include(e => e.Manager);

            if (!string.IsNullOrEmpty(managerId))
                query = query.Where(e => e.ManagerId.ToLower() == managerId.ToLower());

            return query.OrderBy(e => e.EmployeeId).ToList();
        }

        public IEnumerable<Employee> GetAllManagers(string excludedEmployeeId)
        {
            return context.Employees
                          .Where(e => e.EmployeeId.ToLower() != excludedEmployeeId.ToLower())?
                          .OrderBy(e => e.FirstName);
        }

        public Employee GetEmployee(string id)
        {
            return context.Employees
                          .Include(e => e.Manager)
                          .FirstOrDefault(e => e.EmployeeId.ToLower() == id.ToLower());
        }

        public string CreateEmployee(Employee employee)
        {
            context.Add(employee);
            context.SaveChanges();
            
            return employee.EmployeeId;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            context.Employees.Attach(employee);
            context.SaveChanges();

            return employee;
        }

        public void DeleteEmployee(string id)
        {
            context.Employees.Remove(new Employee { EmployeeId = id });
            context.SaveChanges();
        }

        public IEnumerable<ERole> GetAllRoles()
        {
            return context.ERoles.AsNoTracking().OrderBy(r => r.Name)?.ToList();
        }

        public IEnumerable<ERole> GetRoles(string employeeId)
        {
            return (from re in context.EmployeeRoles
                    from r in context.ERoles.AsNoTracking()
                    where re.EmployeeId.ToLower() == employeeId.ToLower() && r.ERoleId == re.ERoleId
                    select r).ToList();
        }

        public void RemoveRoles(string employeeId)
        {
            var dbRoles = context.EmployeeRoles.Where(er => er.EmployeeId.ToLower() == employeeId.ToLower());
            context.EmployeeRoles.RemoveRange(dbRoles);
            context.SaveChanges();
        }
    }
}
