namespace AcademicPublishing.Domain.Models;

public sealed record Author(
    int Id,
    string FirstName,
    string LastName,
    string Affiliation
);
