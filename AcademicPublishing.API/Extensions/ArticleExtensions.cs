using AcademicPublishing.Contracts.Dtos;
using AcademicPublishing.Domain.Models;
using System.Collections.Immutable;

namespace AcademicPublishing.API.Extensions;

public static class ArticleExtensions
{
    public static ArticleDto ToDto(this Article article)
    {
        return new ArticleDto
        {
            Id = article.Id,
            Title = article.Title,
            Abstract = article.Abstract,
            PublicationDate = article.PublicationDate,
            Journal = article.Journal?.ToDto(),
            Authors = article.Authors.Select(x => x.ToDto()).ToImmutableList(),
        };
    }

    public static JournalDto ToDto(this Journal journal)
    {
        return new JournalDto
        {
            Id = journal.Id,
            Name = journal.Name,
            ISSN = journal.ISSN,
            Publisher = journal.Publisher
        };
    }

    public static AuthorDto ToDto(this Author author)
    {
        return new AuthorDto
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            Affiliation = author.Affiliation
        };
    }
}
