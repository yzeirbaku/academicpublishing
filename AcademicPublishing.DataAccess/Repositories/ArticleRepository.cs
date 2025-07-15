using AcademicPublishing.DataAccess.Extensions;
using AcademicPublishing.DataAccess.Models;
using AcademicPublishing.DataAccess.Sql;
using AcademicPublishing.Domain.Exceptions;
using AcademicPublishing.Domain.Models;
using Dapper;
using System.Collections.Immutable;
using System.Data;
using System.Net;

namespace AcademicPublishing.DataAccess.Repositories;

public class ArticleRepository(IDbConnectionFactory connectionFactory) : IArticleRepository
{
    private readonly IDbConnectionFactory _connectionFactory = connectionFactory;

    public async Task<Article> GetByIdAsync(int articleId, CancellationToken cancellationToken)
    {
        using var connection = _connectionFactory.GetConnection();
        var sql = ResourceHelper.ReadSqlEmbeddedResource("GetArticleById");

        CommandDefinition command = new(
            sql,
            new { ArticleId = articleId },
            cancellationToken: cancellationToken
        );

        var articles = await connection.QueryAsync<DbArticle>(command);

        return articles.Any()
            ? articles.ToDomain()[0]
            : throw new AcademicPublishingException(HttpStatusCode.NotFound, $"Article with Id: {articleId} was not found.");
    }

    public async Task<IImmutableList<Article>> GetByAuthorIdAsync(int authorId, CancellationToken cancellationToken)
    {
        using var connection = _connectionFactory.GetConnection();
        await ThrowIfAuthorNotFound(connection, authorId, cancellationToken);

        var sql = ResourceHelper.ReadSqlEmbeddedResource("GetArticlesByAuthorId");
        CommandDefinition command = new(
            sql,
            new { AuthorId = authorId },
            cancellationToken: cancellationToken
        );

        var articles = await connection.QueryAsync<DbArticle>(command);

        return articles.ToDomain();
    }

    public async Task<IImmutableList<Article>> GetByJournalIdAsync(int journalId, CancellationToken cancellationToken)
    {
        using var connection = _connectionFactory.GetConnection();
        await ThrowIfJournalNotFound(connection, journalId, cancellationToken);

        var sql = ResourceHelper.ReadSqlEmbeddedResource("GetArticlesByJournalId");
        CommandDefinition command = new(
            sql,
            new { JournalId = journalId },
            cancellationToken: cancellationToken
        );

        var articles = await connection.QueryAsync<DbArticle>(command);

        return articles.ToDomain();
    }

    private static async Task ThrowIfAuthorNotFound(
        IDbConnection connection,
        int authorId,
        CancellationToken cancellationToken
    )
    {
        var sql = ResourceHelper.ReadSqlEmbeddedResource("CheckAuthorExists");
        CommandDefinition command = new(
            sql,
            new { AuthorId = authorId },
            cancellationToken: cancellationToken
        );

        var _ = await connection.ExecuteScalarAsync<int?>(command)
            ?? throw new AuthorNotFoundException(authorId);
    }

    private static async Task ThrowIfJournalNotFound(
        IDbConnection connection,
        int journalId,
        CancellationToken cancellationToken
    )
    {
        var sql = ResourceHelper.ReadSqlEmbeddedResource("CheckJournalExists");
        CommandDefinition command = new(
            sql,
            new { JournalId = journalId },
            cancellationToken: cancellationToken
        );

        var _ = await connection.ExecuteScalarAsync<int?>(command)
            ?? throw new JournalNotFoundException(journalId);
    }
}
