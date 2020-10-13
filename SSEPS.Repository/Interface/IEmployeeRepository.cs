using SSEPS.Domain;
using System.Collections.Generic;

namespace SSEPS.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees(string managerId = "");
        Employee GetEmployee(string id);
        IEnumerable<Employee> GetAllManagers(string excludedEmployeeId);
        string CreateEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        void DeleteEmployee(string id);
        IEnumerable<ERole> GetAllRoles();
        IEnumerable<ERole> GetRoles(string employeeId);
        void RemoveRoles(string employeeId);
    }
}
