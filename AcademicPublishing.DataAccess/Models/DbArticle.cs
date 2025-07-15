namespace AcademicPublishing.DataAccess.Models;

public record DbArticle
{
    public required int Id { get; init; }
    public required string Title { get; init; }
    public required string Abstract { get; init; }
    public required DateTime PublicationDate { get; init; }

    public int? JournalId { get; init; }
    public string? JournalName { get; init; }
    public string? JournalISSN { get; init; }
    public string? JournalPublisher { get; init; }

    public int? AuthorId { get; init; }
    public string? AuthorFirstName { get; init; }
    public string? AuthorLastName { get; init; }
    public string? AuthorAffiliation { get; init; }
}
