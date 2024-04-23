using System.Runtime.Serialization;

namespace DoctorPatientBLLibrary
{
    [Serializable]
    public class PatientNotExistsException : Exception
    {
        string message;
        public PatientNotExistsException()
        {
            message = "Patient does not exists";
        }
        public override string Message => message;
    }
}