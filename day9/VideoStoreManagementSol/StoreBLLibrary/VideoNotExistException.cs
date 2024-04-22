using System.Runtime.Serialization;

namespace StoreBLLibrary
{
    [Serializable]
    internal class VideoNotExistException : Exception
    {
        string msg;
        public VideoNotExistException()
        {
            msg = "Video Not exists";
        }
        public override string Message => msg;

    }
}