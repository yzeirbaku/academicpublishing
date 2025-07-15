SELECT
    a.Id,
    a.Title,
    a.Abstract,
    a.PublicationDate,
    j.Id AS JournalId,
    j.Name AS JournalName,
    j.ISSN,
    j.Publisher
FROM Articles a
INNER JOIN ArticleAuthors aa ON a.Id = aa.ArticleId
INNER JOIN Journals j ON a.JournalId = j.Id
WHERE aa.AuthorId = @AuthorId;