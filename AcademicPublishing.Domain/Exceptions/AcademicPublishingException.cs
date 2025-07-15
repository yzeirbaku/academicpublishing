using AcademicPublishing.Domain.Exceptions.Models;
using System.Net;

namespace AcademicPublishing.Domain.Exceptions;

/// <summary>
/// A wrapper exception that can be extended with other case-specific exceptions.
/// The exception middleware knows how to handle all derived exceptions from this class.
/// </summary>
public class AcademicPublishingException : Exception
{
    private const HttpStatusCode DefaultHttpStatusCode = HttpStatusCode.InternalServerError;

    public Error Error { get; }

    /// <summary>
    /// Defaults to 500 Internal Server Error
    /// </summary>
    public AcademicPublishingException(string message)
        : base(message)
    {
        Error = new Error(DefaultHttpStatusCode, message);
    }

    /// <summary>
    /// Defaults to 500 Internal Server Error
    /// </summary>
    public AcademicPublishingException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
        Error = new Error(DefaultHttpStatusCode, message);
    }

    public AcademicPublishingException(HttpStatusCode httpStatusCode, string message, Exception? innerException = null)
        : base(message, innerException)
    {
        Error = new Error(httpStatusCode, message);
    }

    public AcademicPublishingException(Error error, Exception? innerException = null)
        : base(error.Message, innerException)
    {
        Error = error;
    }

    public override string ToString()
    {
        return $"StatusCode: {Error.StatusCode}, Message: {Error.Message}";
    }
}
