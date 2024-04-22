using System.Runtime.Serialization;

namespace StoreBLLibrary
{
    [Serializable]
    internal class DuplicateRentalException : Exception
    {
        string msg;
        public DuplicateRentalException()
        {
            msg = "rental already exists";
        }
        public override string Message => msg;

    }
}