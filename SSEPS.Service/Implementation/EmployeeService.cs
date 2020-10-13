using SSEPS.Domain;
using SSEPS.Repository;
using System.Collections.Generic;

namespace SSEPS.Service
{
    public class EmployeeService: IEmployeeService
    {
        private IEmployeeRepository repository;

        public EmployeeService(IEmployeeRepository repo)
        {
            repository = repo;
        }

        public IEnumerable<Employee> GetEmployees(string managerId = "")
        {
            var employees = repository.GetEmployees(managerId);
            
            foreach (var emp in employees)
            {
                if (emp.Manager != null)
                    emp.Manager.Manager = null;
            }

            return employees;
        }

        public IEnumerable<Employee> GetAllManagers(string excludedEmployeeId)
        {
            var managers = repository.GetAllManagers(excludedEmployeeId);
            return managers;
        }

        public Employee GetEmployee(string id)
        {
            var employee = repository.GetEmployee(id);
            
            if (employee?.Manager != null)
                employee.Manager.Manager = null;

            return employee;
        }

        public string CreateEmployee(Employee employee)
        {
            var employeeId = repository.CreateEmployee(employee);
            return employeeId;
        }

        public Employee UpdateEmployee(string id, Employee employee)
        {
            var dbEmployee = repository.GetEmployee(id);
            if (dbEmployee == null)
                return null;

            repository.RemoveRoles(employee.EmployeeId);

            dbEmployee.FirstName = employee.FirstName;
            dbEmployee.LastName = employee.LastName;
            dbEmployee.ManagerId = employee.ManagerId;
            dbEmployee.EmployeeRoles = employee.EmployeeRoles;

            return repository.UpdateEmployee(dbEmployee);
        }

        public void DeleteEmployee(string id)
        {
            repository.DeleteEmployee(id);
        }

        public IEnumerable<ERole> GetAllRoles()
        {
            return repository.GetAllRoles();
        }

        public IEnumerable<ERole> GetRoles(string employeeId)
        {
            return repository.GetRoles(employeeId);
        }

        public void RemoveRoles(string employeeId)
        {
            repository.RemoveRoles(employeeId);
        }
    }
}
