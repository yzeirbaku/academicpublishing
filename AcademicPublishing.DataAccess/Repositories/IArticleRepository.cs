using AcademicPublishing.Domain.Models;
using System.Collections.Immutable;

namespace AcademicPublishing.DataAccess.Repositories;

public interface IArticleRepository
{
    Task<Article> GetByIdAsync(int articleId, CancellationToken cancellationToken);
    Task<IImmutableList<Article>> GetByAuthorIdAsync(int authorId, CancellationToken cancellationToken);
    Task<IImmutableList<Article>> GetByJournalIdAsync(int journalId, CancellationToken cancellationToken);
}
