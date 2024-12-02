using System.Net;
using System.Text.Json;

namespace Project1.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                LogException(ex);

                await HandleExceptionAsync(context, ex);
            }
        }

        private void LogException(Exception ex)
        {
            if (ex is ArgumentException || ex is ArgumentNullException)
            {
                _logger.LogWarning(ex, "A warning occurred: {Message}", ex.Message);
            }
            else if (ex is UnauthorizedAccessException)
            {
                _logger.LogCritical(ex, "Critical security issue: {Message}", ex.Message);
            }
            else
            {
                _logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = new
            {
                traceId = context.TraceIdentifier,
                statusCode = (int)HttpStatusCode.InternalServerError,
                message = "An unexpected error occurred. Please try again later."
            };

            var responsePayload = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = response.statusCode;

            return context.Response.WriteAsync(responsePayload);
        }
    }
}