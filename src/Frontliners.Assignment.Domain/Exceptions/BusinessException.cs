
namespace Frontliners.Assignment.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public string ErrorCode { get; set; }

        public BusinessException(string message) : this(message, Constants.DefaultErrorCode) { }

        public BusinessException(string message, string code) : base(message)
        {
            ErrorCode = code;
        }
    }
}
