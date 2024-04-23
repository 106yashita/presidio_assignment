using RequestDALLibrary;
using RequestModelClassLibrary;

namespace RequestProjectTest
{
    public class Tests
    {
        IRepository<int, Department> repository;
        [SetUp]
        public void Setup()
        {
            repository = new DepartmentRepository();
        }

        [TestCase(1, "Hr", 101)]
        [TestCase(2, "Admin", 101)]
        public void GetPassTest(int id, string name, int hid)
        {
            //Arrange 
            Department department = new Department() { Name = name, Department_Head = hid };
            repository.Add(department);

            //Action
            var result = repository.Get(id);
            //Assert
            Assert.IsNotNull(result);
        }


        //[Test]
        public void AddFailTest()
        {
            // Arrange
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            department = new Department() { Name = "IT", Department_Head = 102 };
            //Action
            var result = repository.Add(department);
            //Assert
            Assert.IsNull(result);
        }
        //[Test]
        //public void GetAllTest()
        //{
        //    //Arrange
        //    Department department1 = new Department() { Name = "IT", Department_Head = 101 };
        //    Department department2 = new Department() { Name = "HR", Department_Head = 102 };
        //    repository.Add(department1);
        //    repository.Add(department2);

        //    // Action
        //    var result = repository.GetAll();

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(2, result.Count);
        //}
    }

}