
using RequestBLLibrary;
using RequestDALLibrary;
using RequestModelClassLibrary;

namespace RequestBLTest
{
    public class Tests
    {
        IRepository<int, Department> repository;
        IDepartmentService departmentService;
        [SetUp]
        public void Setup()
        {
            repository = new DepartmentRepository();
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            departmentService = new DepartmentBL(repository);
        }

        [Test]
        public void GetDepartmnetByNameTest()
        {
            var department = departmentService.GetDepartmentByName("IT");
            Assert.AreEqual(1,department.Id);
        }

        [Test]
        public void GetDepartmnetByNameExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DepartmentNotExistException>(() => departmentService.GetDepartmentByName("Admin"));
            //Assert
            Assert.AreEqual("Department does not exists", exception.Message);
        }
    }
}