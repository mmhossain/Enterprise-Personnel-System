using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSEPS.Domain;
using SSEPS.Service;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using Microsoft.Extensions.Logging;

namespace ServerApp.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : Controller
    {
        //private readonly ILogger<EmployeeController> logger;
        private readonly IEmployeeService service;
        
        //public EmployeeController(IEmployeeService service, ILogger<EmployeeController> logger)
        public EmployeeController(IEmployeeService service) 
        {
            this.service = service;
            //this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Employee> GetEmployees(string managerId = "")
        {
            //logger.LogInformation($"GetEmployees: Getting all employees for manager: {managerId}");
            
            return service.GetEmployees(managerId);
        }

        [HttpGet("managers/{excludedEmployeeId}")]
        public IEnumerable<Employee> GetAllManagers(string excludedEmployeeId)
            => service.GetAllManagers(excludedEmployeeId);

        [HttpGet("{id}")]
        public Employee GetEmployee(string id) 
            => service.GetEmployee(id);

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee) 
        {
            if (ModelState.IsValid) 
            {
                var employeeId = service.CreateEmployee(employee);
                
                return Ok(employeeId);
            }
            
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult ReplaceEmployee(string id, [FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var updatedEmployee = service.UpdateEmployee(id, employee);
                if (updatedEmployee == null)
                    return NotFound();

                return Ok(updatedEmployee);
            }
            
            return BadRequest(ModelState);
        }

        //[HttpPatch("{id}")]
        //public IActionResult UpdateEmployee(string id, [FromBody]JsonPatchDocument<Employee> patch)
        //{
        //    var employee = context.Employees
        //                        .Include(e => e.Manager)
        //                        .Include(e => e.EmployeeRoles)
        //                        .FirstOrDefault(e => string.Equals(e.EmployeeId, id, System.StringComparison.OrdinalIgnoreCase));

        //    patch.ApplyTo(employee, ModelState);

        //    if (ModelState.IsValid && TryValidateModel(employee))
        //    {
        //        context.SaveChanges();

        //        return Ok();
        //    }

        //    return BadRequest(ModelState);
        //}

        [HttpDelete("{id}")]
        public void DeleteEmployee(string id)
            => service.DeleteEmployee(id);

        [HttpGet("roles")]
        public IEnumerable<ERole> GetAllRoles()
            => service.GetAllRoles();

        [HttpGet("roles/{empId}")]
        public IEnumerable<ERole> GetRoles(string empId)
            => service.GetRoles(empId);
    }
}
