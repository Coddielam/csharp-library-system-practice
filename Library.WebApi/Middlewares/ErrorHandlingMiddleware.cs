using System.Net;

namespace Library.WebApi.Middlewares;

public class ErrorHandlingMiddleware : IMiddleware
{
    private readonly RequestDelegate _next;

    private readonly ILogger _logger;

    public ErrorHandlingMiddleware(
        RequestDelegate next,
        ILogger logger
    )
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new
        {
            context.Response.StatusCode,
            Message = "An unexpected error has occured"
        };

        return context.Response.WriteAsJsonAsync(response);
    }
}

public static class ErrorHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorHandlingMiddleware(
        this IApplicationBuilder builder
    )
    {
        return builder.UseMiddleware<ErrorHandlingMiddleware>();
    }
}