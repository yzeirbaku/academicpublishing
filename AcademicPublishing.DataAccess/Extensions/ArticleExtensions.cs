using AcademicPublishing.DataAccess.Models;
using AcademicPublishing.Domain.Models;
using System.Collections.Immutable;

namespace AcademicPublishing.DataAccess.Extensions;

public static class ArticleExtensions
{
    public static IImmutableList<Article> ToDomain(this IEnumerable<DbArticle> dbArticles)
    {
        return dbArticles
            .GroupBy(r => r.Id)
            .Select(group =>
            {
                var first = group.First();

                var authors = group
                    .Where(x => x.AuthorId.HasValue)
                    .Select(x => new Author(
                        x.AuthorId!.Value,
                        x.AuthorFirstName!,
                        x.AuthorLastName!,
                        x.AuthorAffiliation!
                    ))
                    .ToImmutableList();

                Journal? journal = null;
                if (first.JournalId.HasValue)
                {
                    journal = new Journal(
                        first.JournalId.Value,
                        first.JournalName!,
                        first.JournalISSN!,
                        first.JournalPublisher!
                    );
                }

                return new Article(
                    first.Id,
                    first.Title!,
                    first.Abstract!,
                    DateOnly.FromDateTime(first.PublicationDate),
                    journal,
                    authors
                );
            })
            .ToImmutableList();
    }
}
