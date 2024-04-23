using System.Runtime.Serialization;

namespace DoctorPatientBLLibrary
{
    [Serializable]
    public class DoctorNotExistsException : Exception
    {
        string message;
        public DoctorNotExistsException()
        {
            message = "Doctor does not exists";
        }
        public override string Message => message;
    }
}