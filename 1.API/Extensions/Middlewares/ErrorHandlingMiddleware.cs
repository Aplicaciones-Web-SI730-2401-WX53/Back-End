using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net;

namespace _1.API.Extensions.Middlewares;

public class ErrorHandlingMiddleware
{
    
    private readonly RequestDelegate _next;
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = string.Empty;
        
        if (ex is DuplicateNameException || ex is ConstraintException)
        {
            code = HttpStatusCode.Conflict;
            result = ex.Message;
        }
        else if (ex is ArgumentException)
        {
            code = HttpStatusCode.BadRequest;
            result = ex.Message;
        } 

        else
        {
            code = HttpStatusCode.InternalServerError;
            result = "Internal Server Error";
        }
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        await context.Response.WriteAsync(result);
        
    }
    
}