using System.Runtime.Serialization;

namespace StoreBLLibrary
{
    [Serializable]
    internal class DuplicateVideoException : Exception
    {
        string msg;
        public DuplicateVideoException()
        {
            msg = "Video already exists";
        }
        public override string Message => msg;
    }
}