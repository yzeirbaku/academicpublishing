using System.Net;

namespace AcademicPublishing.Domain.Exceptions;

public sealed class AuthorNotFoundException(int authorId)
    : AcademicPublishingException(HttpStatusCode.NotFound, $"Author with Id: {authorId} was not found.");
