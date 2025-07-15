namespace AcademicPublishing.Contracts.Dtos;

public record AuthorDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Affiliation { get; set; } = string.Empty;
}
