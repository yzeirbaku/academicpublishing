using AcademicPublishing.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Net;
using System.Text.Json;

namespace AcademicPublishing.API.Middleware;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (AcademicPublishingException ex)
        {
            await HandleAcademicPublishingExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleGeneralExceptionAsync(context, ex);
        }
    }

    private Task HandleAcademicPublishingExceptionAsync(HttpContext context, AcademicPublishingException exception)
    {
        int statusCode = exception.Error.StatusCode;
        LogException(context, exception, statusCode);

        string title = "An error occurred.";
        string detail = exception.Error.Message;

        return FormatProblemDetailsResponseAsync(context, statusCode, title, detail);
    }

    private Task HandleGeneralExceptionAsync(HttpContext context, Exception exception)
    {
        int statusCode = (int)HttpStatusCode.InternalServerError;
        LogException(context, exception, statusCode);

        string title = "An unexpected error occurred.";
        string detail = exception.Message;

        return FormatProblemDetailsResponseAsync(context, statusCode, title, detail);
    }

    private static Task FormatProblemDetailsResponseAsync(HttpContext context, int statusCode, string title, string detail)
    {
        ProblemDetails problemDetails = new()
        {
            Status = statusCode,
            Title = title,
            Detail = detail,
            Instance = context.Request.Path
        };

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/problem+json";

        string responseJson = JsonSerializer.Serialize(problemDetails);

        return context.Response.WriteAsync(responseJson);
    }

    private void LogException(HttpContext context, Exception exception, int statusCode)
    {
        var endpoint = context.GetEndpoint();
        string? controllerName = default;
        string? actionName = default;

        if (endpoint is not null)
        {
            var routeValues = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();
            if (routeValues is not null)
            {
                controllerName = routeValues.ControllerName;
                actionName = routeValues.ActionName;
            }
        }

        _logger.LogError(
            exception,
            "Exception occurred in {controllerName}/{actionName} at {path} with status code {statusCode}.",
            controllerName ?? "Unknown",
            actionName ?? "Unknown",
            context.Request.Path,
            statusCode
        );
    }
}
