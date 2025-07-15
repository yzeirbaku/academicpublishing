using System.Net;

namespace AcademicPublishing.Domain.Exceptions.Models;

public sealed record Error
{
    public HttpStatusCode HttpStatusCode { get; init; }
    public string Message { get; init; }

    public Error(HttpStatusCode httpStatusCode, string message)
    {
        HttpStatusCode = httpStatusCode;
        Message = message;
    }

    public int StatusCode => (int)HttpStatusCode;
}
