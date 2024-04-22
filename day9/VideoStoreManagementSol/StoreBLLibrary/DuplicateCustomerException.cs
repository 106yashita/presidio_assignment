using System.Runtime.Serialization;

namespace StoreBLLibrary
{
    [Serializable]
    internal class DuplicateCustomerException : Exception
    {
        string msg;
        public DuplicateCustomerException()
        {
            msg = "Customer Already exists";
        }
        public override string Message => msg;

    }
}