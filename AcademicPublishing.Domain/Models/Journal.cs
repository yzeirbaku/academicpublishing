namespace AcademicPublishing.Domain.Models;

public sealed record Journal(
    int Id,
    string Name,
    string ISSN,
    string Publisher
);
