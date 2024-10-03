using Frontliners.Assignment.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace Frontliners.Assignment.Api.Middleware.Exceptions
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Api Error");
                await HandleException(ex, httpContext);
            }
        }

        private async Task HandleException(Exception ex, HttpContext httpContext)
        {
            httpContext.Response.ContentType = "application/json";
            var errorMessage = new ErrorMessage
            {
                Message = ex.Message,
                IsBusinessError = false
            };
            if (ex is BusinessException businessException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorMessage.Message = businessException.Message;
                errorMessage.ErrorCode = businessException.ErrorCode;
                errorMessage.IsBusinessError = true;
            }
            else if (ex is ArgumentException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorMessage));
        }
    }
}
