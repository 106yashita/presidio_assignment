namespace EmployeeRequestTrackerAPI.models
{
    public class ErrorModel
    {

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public ErrorModel(int code, string message)
        {
            this.ErrorCode = code;
            this.ErrorMessage = message;
        }

    }
}
