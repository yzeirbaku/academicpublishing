using System.Net;

namespace AcademicPublishing.Domain.Exceptions;

public sealed class JournalNotFoundException(int journalId)
    : AcademicPublishingException(HttpStatusCode.NotFound, $"Journal with Id: {journalId} was not found.");