using System.Runtime.Serialization;

namespace RequestTrackerBLLibrary
{
    [Serializable]
    internal class NoSolutionExists : Exception
    {
        string message;
        public NoSolutionExists()
        {
            message = "No solution exists";
        }
        public override string Message => message;

    }
}