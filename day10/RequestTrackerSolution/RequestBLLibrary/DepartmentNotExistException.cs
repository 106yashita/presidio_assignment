using System.Runtime.Serialization;

namespace RequestBLLibrary
{
   
    public class DepartmentNotExistException : Exception
    {
        string msg;
        public DepartmentNotExistException()
        {
            msg = "Department does not exists";
        }

        public DepartmentNotExistException(string name)
        {
            msg = "Department does not exists  with name " +name;
        }
        public override string Message => msg;
    }
}