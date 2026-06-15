using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace NewtonServices.Helpers
{
    public class ErrorHandler(ILogger<ErrorHandler> _logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {

            _logger.LogError(exception, "API Exception: {Message}", exception.Message);
            
            var statusCode = StatusCodes.Status500InternalServerError;
            var title = "Internal Server Error";
            var detail = "An unexpected error occurred while processing the request.";

            switch (exception)
            {
                case BadHttpRequestException e:
                    statusCode = StatusCodes.Status400BadRequest;
                    title = "Bad Request";
                    detail = "The request could not be understood by the server.";
                    break;
                case KeyNotFoundException e:
                    statusCode = StatusCodes.Status404NotFound;
                    title = "Resource Not Found";
                    detail = "The requested resource could not be found.";
                    break;
                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    title = "Internal Server Error";
                    detail = "An unexpected error occurred while processing the request.";
                    break;
            }

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = detail
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}