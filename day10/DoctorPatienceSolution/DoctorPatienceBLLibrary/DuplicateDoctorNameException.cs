using System.Runtime.Serialization;

namespace DoctorPatientBLLibrary
{
    [Serializable]
    public class DuplicateDoctorNameException : Exception
    {
        string message;
        public DuplicateDoctorNameException()
        {
            message = "Doctor already exist with this name";
        }
        public override string Message => message;

    }
}