namespace ams.web.api.Middlewares;

internal class ExceptionMiddleware(RequestDelegate _next, ILogger<ExceptionMiddleware> _logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var statusCode = exception switch
        {
            ArgumentNullException => StatusCodes.Status400BadRequest,
            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
            RecordNotFoundException => StatusCodes.Status404NotFound, // Custom Exception
            _ => StatusCodes.Status500InternalServerError
        };

        context.Response.StatusCode = statusCode;

        var response = new
        {
            Message = exception switch
            {
                ArgumentNullException => "A required parameter was missing.",
                UnauthorizedAccessException => "Access denied.",
                RecordNotFoundException => exception.Message,
                _ => "An unexpected error occurred."
            },
            ExceptionType = exception.GetType().Name,
            Details = exception.Message
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
