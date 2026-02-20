using FluentValidation;
using System.Net;
using System.Text.Json;

namespace INotesV2.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException e)
            {
                await HandleValidationExceptionAsync(context, e);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        public static Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var errors = exception.Errors
                .GroupBy(n => n.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

            var response = new
            {
                type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                message = "Validation failed",
                title = "One or more validation errors occurred.",
                status = 400,
                errors
            };
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        public static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                message = "An unexpected error occurred.",
                title = "Internal Server Error",
                status = 500,
                detail = exception.Message
            };
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
