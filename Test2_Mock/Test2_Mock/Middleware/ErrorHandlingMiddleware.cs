using System.Net;
using Test2_Mock.Exceptions;

namespace Test2_Mock.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); //endpoint processing
        }
        catch (BadRequestException ex)
        {
            await HandleExceptionAsync(context, ex, (int)HttpStatusCode.BadRequest);
        }
        catch (NotFoundException ex)
        {
            await HandleExceptionAsync(context, ex, (int)HttpStatusCode.NotFound);
        }
        catch (ForbiddenException ex)
        {
            await HandleExceptionAsync(context, ex, (int)HttpStatusCode.Forbidden);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, (int)HttpStatusCode.Conflict);
        }
    }
    private Task HandleExceptionAsync(HttpContext context, Exception exception,int statusCode)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        var response = new
        {
            error = new
            {
                message = "An error has occured while the endpoint was processed.",
                details = exception.Message
            }
        };
        //Serialize the response model to JSON
        var jsonResponse = System.Text.Json.JsonSerializer.Serialize(response);
        //Write the JSON response to the HTTP response
        return context.Response.WriteAsync(jsonResponse);
    }
}