
namespace RequestBLLibrary
{

    public class DuplicateDepartmentNameException : Exception
    {
        string msg;
        public DuplicateDepartmentNameException()
        {
            msg = "Department name already exists";
        }
        public override string Message => msg;
    }
}