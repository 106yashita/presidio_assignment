using System.Runtime.Serialization;

namespace RequestBLLibrary
{
    [Serializable]
    public class DuplicateEmployeeNameException : Exception
    {
        string msg;
        public DuplicateEmployeeNameException()
        {
            msg = "Employee name already exists";

        }
        public override string Message => msg;
    }
}