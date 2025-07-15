using System.Net;

namespace AcademicPublishing.Domain.Exceptions;

public sealed class ArticleNotFoundException(int articleId)
    : AcademicPublishingException(HttpStatusCode.NotFound, $"Article with Id: {articleId} was not found.");
