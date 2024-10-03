
namespace Frontliners.Assignment.Domain.Exceptions
{
    public class ErrorMessage
    {
        public string Message { get; set; }
        public string ErrorCode { get; set; } = Constants.DefaultErrorCode;
        public bool IsBusinessError { get; set; }
    }
}
