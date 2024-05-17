using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class UnableToRegisterException : Exception
    {
        string message;
        public UnableToRegisterException(string? message) : base(message)
        {
            message = message;
        }

        public override string Message => message;
    }
}