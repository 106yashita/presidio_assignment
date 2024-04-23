using System.Runtime.Serialization;

namespace RequestBLLibrary
{
    [Serializable]
    internal class EmployeeNotExistException : Exception
    {
        string msg;
        public EmployeeNotExistException()
        {
            msg = "Employee does not exists ";
        }
        public override string Message => msg;

        
    }
}