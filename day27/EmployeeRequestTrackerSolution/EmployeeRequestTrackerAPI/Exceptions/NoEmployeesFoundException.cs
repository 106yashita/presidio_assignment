using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class NoEmployeesFoundException : Exception
    {
        string message;
        public NoEmployeesFoundException()
        {
            message = "No employee found";
        }
        public override string Message => message;

    }
}