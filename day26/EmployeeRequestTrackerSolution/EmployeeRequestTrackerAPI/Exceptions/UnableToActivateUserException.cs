using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class UnableToActivateUserException : Exception
    {
        string message;

        public UnableToActivateUserException(string? message) : base(message)
        {
            message = message;
        }
        public override string Message => message;

    }
}