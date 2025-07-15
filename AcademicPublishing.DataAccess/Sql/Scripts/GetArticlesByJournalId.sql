SELECT
    a.Id,
    a.Title,
    a.Abstract,
    a.PublicationDate,
    au.Id AS AuthorId,
    au.FirstName,
    au.LastName,
    au.Affiliation
FROM Articles a
LEFT JOIN ArticleAuthors aa ON a.Id = aa.ArticleId
LEFT JOIN Authors au ON aa.AuthorId = au.Id
WHERE a.JournalId = @JournalId;