using System.Collections.Immutable;

namespace AcademicPublishing.Contracts.Dtos;

public record ArticleDto
{
    public required int Id { get; init; }
    public required string Title { get; init; }
    public required string Abstract { get; init; }
    public required DateOnly PublicationDate { get; init; }
    public JournalDto? Journal { get; init; }
    public IImmutableList<AuthorDto> Authors { get; init; } = [];
}
