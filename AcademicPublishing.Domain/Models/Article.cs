using System.Collections.Immutable;

namespace AcademicPublishing.Domain.Models;

public sealed record Article(
    int Id,
    string Title,
    string Abstract,
    DateOnly PublicationDate,
    Journal? Journal,
    IImmutableList<Author> Authors
);
