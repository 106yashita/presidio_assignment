using System.Runtime.Serialization;

namespace StoreBLLibrary
{
    [Serializable]
    internal class CustomerNotExistException : Exception
    {
        string msg;
        public CustomerNotExistException()
        {
            msg = "Customer does not exists";
        }
        public override string Message => msg;
       
    }
}