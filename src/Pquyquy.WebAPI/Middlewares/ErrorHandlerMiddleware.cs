using Pquyquy.Application.Exceptions;
using Pquyquy.Application.Wrappers;
using System.Net;

namespace Pquyquy.WebAPI.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
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

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";
        var responseModel = new Response<string>
        {
            Succeeded = false,
            Message = exception.Message
        };

        switch (exception)
        {
            case ApiException:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            case ValidationException e:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                responseModel.Errors = e.Errors;
                break;
            case DbUpdateException e:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                responseModel.Errors = new List<string>
                {
                    $"innerException: {e.InnerException}",
                    $"stackTrace: {e.StackTrace}"
                };
                break;
            case KeyNotFoundException:
                response.StatusCode = (int)HttpStatusCode.NotFound;
                break;
            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                responseModel.Errors = new List<string>
                {
                    $"innerException: {exception.InnerException}",
                    $"stackTrace: {exception.StackTrace}"
                };
                break;
        }

        var result = JsonConvert.SerializeObject(responseModel);
        return response.WriteAsync(result);
    }
}
