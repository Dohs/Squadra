using Microsoft.AspNetCore.Http;
using WebApi.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.Middleware;

    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ILogService logService)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, logService);
            }
        }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception, ILogService logService)
    {
        await logService.LogError($"An unhandled exception has occurred: {exception.Message}", exception);

        context.Response.ContentType = "application/json";
        var response = new { StatusCode = 500, Message = "Internal Server Error. Please try again later." };

        switch (exception)
        {
            case ArgumentException argEx:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                response = new { StatusCode = 400, Message = argEx.Message };
                break;
            case KeyNotFoundException:
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                response = new { StatusCode = 404, Message = "Resource not found." };
                break;
            default:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        await context.Response.WriteAsJsonAsync(response);
    }
}

