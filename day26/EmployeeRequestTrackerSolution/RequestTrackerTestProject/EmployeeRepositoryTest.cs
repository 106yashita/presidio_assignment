using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Repositories;
using EmployeeRequestTrackerAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerTestProject
{
    public class EmployeeRepositoryTest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Structure", "NUnit1032:An IDisposable field/property should be Disposed in a TearDown method", Justification = "<Pending>")]
        RequestTrackerContext context;
        IRepository<int, Employee> employeeRepo;
        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder()
                                                        .UseInMemoryDatabase("dummyDB");
            context = new RequestTrackerContext(optionsBuilder.Options);
            employeeRepo = new EmployeeRepository(context);
            employeeRepo.Add(new Employee
            {
                Id = 101,
                Name = "Test1",
                DateOfBirth = new DateTime(2002, 12, 12),
                Phone = "9988776655",
                Role = "Admin",
                Image = ""
            });

        }
        [Test]
        public void GetEmployeeTest()
        {
            //Arrange
            IEmployeeService employeeService = new EmployeeBasicService(employeeRepo);

            //Action
            var result = employeeService.GetEmployeeByPhone("9988776655");

            //Assert
            Assert.That(result, Is.Not.Null);

        }
    }
}
