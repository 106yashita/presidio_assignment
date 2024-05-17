using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class NoSuchEmployeeException : Exception
    {
        string message;
        public NoSuchEmployeeException()
        {
            message = "No such employee exists";
        }
        public override string Message => message;

    }
}