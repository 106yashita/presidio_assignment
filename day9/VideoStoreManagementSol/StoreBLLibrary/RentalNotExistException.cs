using System.Runtime.Serialization;

namespace StoreBLLibrary
{
    [Serializable]
    internal class RentalNotExistException : Exception
    {
        string msg;
        public RentalNotExistException()
        {
            msg = "Rental does not exists";
        }
        public override string Message => msg;

    }
}