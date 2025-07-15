namespace AcademicPublishing.Contracts.Dtos;

public record JournalDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string ISSN { get; init; } = string.Empty;
    public string Publisher { get; init; } = string.Empty;
}
