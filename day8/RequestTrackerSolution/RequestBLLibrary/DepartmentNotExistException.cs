using System.Runtime.Serialization;

namespace RequestBLLibrary
{
   
    public class DepartmentNotExistException : Exception
    {
        string msg;
        public DepartmentNotExistException()
        {
            msg = "Department does not exists ";
        }
        public override string Message => msg;
    }
}