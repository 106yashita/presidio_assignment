using System.Runtime.Serialization;

namespace ClinicAPI.Exceptions
{
    [Serializable]
    internal class NoDoctorFoundException : Exception
    {
        string message;
        public NoDoctorFoundException()
        {
            message = "No doctor found";
        }
        public override string Message => message;

    }
}