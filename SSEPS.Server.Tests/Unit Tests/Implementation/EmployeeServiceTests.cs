using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SSEPS.Domain;
using SSEPS.Repository;
using SSEPS.Service;
using System.Collections.Generic;
using System.Linq;

namespace SSEPS.Server.Tests
{
    [TestClass()]
    public class EmployeeServiceTests
    {
        private Mock<IEmployeeRepository> repository;
        private IEmployeeService service;

        [TestInitialize]
        public void Init()
        {
            repository = new Mock<IEmployeeRepository>();
            service = new EmployeeService(repository.Object);
        }

        [TestMethod()]
        public void GetEmployees_ShouldReturnAllEmployeesForEmptyManagerId()
        {
            // Arrange
            var employees = new List<Employee> {
                new Employee{EmployeeId = "1", Manager = new Employee()},
                new Employee{EmployeeId = "3"},
                new Employee{EmployeeId = "2", Manager = new Employee()}
            };

            repository.Setup(r => r.GetEmployees(""))
                      .Returns(employees);

            // Act
            var result = service.GetEmployees("");
            
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod()]
        public void GetEmployees_ShouldReturnEmployeesForValidManagerId()
        {
            // Arrange
            string fakeManagerId = "1";
            var employees = new List<Employee> {
                new Employee{EmployeeId = "2", ManagerId = fakeManagerId }
            };

            repository.Setup(r => r.GetEmployees(fakeManagerId))
                      .Returns(employees);

            // Act
            var result = service.GetEmployees(fakeManagerId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(fakeManagerId, ((Employee)result.FirstOrDefault()).ManagerId);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod()]
        public void GetEmployees_ShouldRemoveCircularReferenceBetweenManagerAndEmployee()
        {
            // Arrange
            var employees = new List<Employee> {
                new Employee{EmployeeId = "1", Manager = new Employee { Manager = new Employee() } },
                new Employee{EmployeeId = "2", Manager = new Employee { Manager = new Employee() } }
            };

            repository.Setup(r => r.GetEmployees(""))
                      .Returns(employees);

            // Act
            IEnumerable<Employee> result = service.GetEmployees("");

            // Assert
            Assert.IsNotNull(result);
            foreach (var emp in result)
                Assert.IsNull(emp.Manager.Manager);
        }

        [TestMethod()]
        public void GetAllManagers_ShouldReturnAllManagersExceftSelf()
        {
            // Arrange
            var employees = new List<Employee> {
                new Employee{EmployeeId = "1", Manager = new Employee { Manager = new Employee() } },
                new Employee{EmployeeId = "2", Manager = new Employee { Manager = new Employee() } },
                new Employee{EmployeeId = "3", Manager = new Employee { Manager = new Employee() } },
                new Employee{EmployeeId = "4", Manager = new Employee { Manager = new Employee() } }
            };
            var testEmployeeId = "2";
            repository.Setup(r => r.GetAllManagers(testEmployeeId))
                      .Returns(employees.Where(e => e.EmployeeId != testEmployeeId));

            // Act
            IEnumerable<Employee> result = service.GetAllManagers(testEmployeeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            
            var testEmployee = result.FirstOrDefault(e => e.EmployeeId == testEmployeeId);
            Assert.IsNull(testEmployee);
        }

        [TestMethod()]
        public void GetEmployee_ShouldEmployeeWithValidEmployeeId()
        {
            // Arrange
            var employees = new List<Employee> {
                new Employee{EmployeeId = "1", Manager = new Employee { Manager = new Employee() } },
                new Employee{EmployeeId = "2", Manager = new Employee { Manager = new Employee() } },
                new Employee{EmployeeId = "3", Manager = new Employee { Manager = new Employee() } },
                new Employee{EmployeeId = "4", Manager = new Employee { Manager = new Employee() } }
            };
            var testEmployeeId = "2";
            repository.Setup(r => r.GetEmployee(testEmployeeId))
                      .Returns(employees.FirstOrDefault(e => e.EmployeeId == testEmployeeId));

            // Act
            var result = service.GetEmployee(testEmployeeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("2", result.EmployeeId);
        }

        [TestMethod()]
        public void GetEmployee_ShouldRemoveCircularReferenceBetweenEmployeeAndManager()
        {
            // Arrange
            var employees = new List<Employee> {
                new Employee{EmployeeId = "1", Manager = new Employee { Manager = new Employee() } },
                new Employee{EmployeeId = "2", Manager = new Employee { Manager = new Employee() } },
                new Employee{EmployeeId = "3", Manager = new Employee { Manager = new Employee() } },
                new Employee{EmployeeId = "4", Manager = new Employee { Manager = new Employee() } }
            };
            var testEmployeeId = "2";
            repository.Setup(r => r.GetEmployee(testEmployeeId))
                      .Returns(employees.FirstOrDefault(e => e.EmployeeId == testEmployeeId));

            // Act
            var result = service.GetEmployee(testEmployeeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Manager.Manager);
        }
    }
}