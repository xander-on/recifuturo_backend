using System.Net;
using System.Text.Json;
using FluentValidation;

namespace RecifuturoBackend.Shared.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors
                .Select(e => e.ErrorMessage)
                .ToList();

            await HandleException(context, HttpStatusCode.BadRequest, errors);
        }
        catch (ConflictException ex)
        {
            await HandleException(context, HttpStatusCode.Conflict, ex.Message);
        }
        catch (BadRequestException ex)
        {
            await HandleException(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            await HandleException(context, HttpStatusCode.InternalServerError, $"Error interno: {ex.Message}");
        }
    }



    private static async Task HandleException(HttpContext context, HttpStatusCode status, object message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;

        // var errors = message is string s
        //     ? [s] 
        //     : message as IEnumerable<string> ?? ["Error interno"];

        var errors = message switch
        {
            string s => [s],
            IEnumerable<string> list => list,
            _ => ["Error interno"]
        };

        var response = new { errors };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}