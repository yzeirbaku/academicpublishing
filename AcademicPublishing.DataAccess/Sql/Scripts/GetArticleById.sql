SELECT
    a.Id,
    a.Title,
    a.Abstract,
    a.PublicationDate,
    j.Id AS JournalId,
    j.Name AS JournalName,
    j.ISSN AS JournalISSN,
    j.Publisher AS JournalPublisher,
    au.Id AS AuthorId,
    au.FirstName AS AuthorFirstName,
    au.LastName AS AuthorLastName,
    au.Affiliation AS AuthorAffiliation
FROM Articles a
INNER JOIN Journals j ON a.JournalId = j.Id
LEFT JOIN ArticleAuthors aa ON a.Id = aa.ArticleId
LEFT JOIN Authors au ON aa.AuthorId = au.Id
WHERE a.Id = @ArticleId;