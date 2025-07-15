using AcademicPublishing.API.Extensions;
using AcademicPublishing.Contracts.Dtos;
using AcademicPublishing.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AcademicPublishing.API.Controllers;

[ApiController]
[Route("api/articles")]
public class ArticlesController(IArticleRepository articleRepository) : ControllerBase
{
    private readonly IArticleRepository _articleRepository = articleRepository;

    /// <summary>
    /// Gets a single article by Id, including its journal and authors.
    /// </summary>
    /// <param name="id">The Id of the article.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The article with journal and author info.</returns>
    /// <response code="200">If the article is found.</response>
    /// <response code="404">If the article is not found.</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ArticleDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ArticleDto> GetById(int id, CancellationToken cancellationToken)
    {
        var article = await _articleRepository.GetByIdAsync(id, cancellationToken);

        return article.ToDto();
    }

    /// <summary>
    /// Gets all articles written by a specific author.
    /// </summary>
    /// <param name="authorId">The Id of the author.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of articles authored by the given author.</returns>
    /// <response code="200">If the articles are found.</response>
    /// <response code="404">If the author is not found.</response>
    [HttpGet("author/{authorId:int}")]
    [ProducesResponseType(typeof(ArticleDto[]), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ArticleDto[]> GetByAuthorId(int authorId, CancellationToken cancellationToken)
    {
        var articles = await _articleRepository.GetByAuthorIdAsync(authorId, cancellationToken);

        return [.. articles.Select(a => a.ToDto())];
    }

    /// <summary>
    /// Gets all articles published in a specific journal.
    /// </summary>
    /// <param name="journalId">The Id of the journal.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of articles in the journal.</returns>
    /// <response code="200">If the articles are found.</response>
    /// <response code="404">If the journal is not found.</response>
    [HttpGet("journal/{journalId:int}")]
    [ProducesResponseType(typeof(ArticleDto[]), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ArticleDto[]> GetByJournalId(int journalId, CancellationToken cancellationToken)
    {
        var articles = await _articleRepository.GetByJournalIdAsync(journalId, cancellationToken);

        return [.. articles.Select(a => a.ToDto())];
    }
}
