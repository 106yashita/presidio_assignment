using System.Runtime.Serialization;

namespace ClinicAPI.Exceptions
{
    [Serializable]
    internal class NoSuchDoctorException : Exception
    {
        string message;
        public NoSuchDoctorException()
        {
            message = "No doctor exists";
        }
        public override string Message => message;


    }
}