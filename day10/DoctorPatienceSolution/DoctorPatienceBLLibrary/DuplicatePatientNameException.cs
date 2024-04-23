using System.Runtime.Serialization;

namespace DoctorPatientBLLibrary
{
    [Serializable]
    public class DuplicatePatientNameException : Exception
    {
        string message;
        public DuplicatePatientNameException()
        {
            message = "Patient already exists";
        }
        public override string Message => message;

    }
}