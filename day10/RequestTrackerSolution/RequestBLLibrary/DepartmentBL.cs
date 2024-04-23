using RequestDALLibrary;
using RequestModelClassLibrary;

namespace RequestBLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL(IRepository<int, Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }

        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            List<Department> departments = _departmentRepository.GetAll();
            foreach(Department department in departments)
            {
                if(department.Name == departmentOldName)
                {
                    department.Name = departmentNewName;
                    return department;
                }
            }
            throw new DepartmentNotExistException();
        }

        public Department GetDepartmentById(int id)
        {
            Department department=_departmentRepository.Get(id);
            if (department != null) 
            {
                return department;
            }
            throw new DepartmentNotExistException();
        }

        public Department GetDepartmentByName(string departmentName)
        {
            List<Department> departments= _departmentRepository.GetAll();
            foreach (Department department in departments)
            {
                if(department.Name == departmentName) { return department; }
            }
            throw new DepartmentNotExistException();
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            Department department = _departmentRepository.Get(departmentId);
            if (department != null)
            {
                return department.Department_Head;
            }
            throw new DepartmentNotExistException();

        }

        public List<Department> GetDepartmentList()
        {
            List<Department> list = _departmentRepository.GetAll();
            return list;
        }
    }
}
