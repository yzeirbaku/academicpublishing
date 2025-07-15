CREATE TABLE Journals (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    ISSN NVARCHAR(20) NOT NULL,
    Publisher NVARCHAR(255) NOT NULL
);

CREATE TABLE Authors (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Affiliation NVARCHAR(255) NOT NULL
);

CREATE TABLE Articles (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(500) NOT NULL,
    Abstract NVARCHAR(4000) NOT NULL,
    PublicationDate DATE NOT NULL,
    JournalId INT NOT NULL,
    CONSTRAINT FK_Articles_Journals FOREIGN KEY (JournalId) REFERENCES Journals(Id) ON DELETE CASCADE
);

CREATE TABLE ArticleAuthors (
    ArticleId INT NOT NULL,
    AuthorId INT NOT NULL,
    CONSTRAINT PK_ArticleAuthors PRIMARY KEY (ArticleId, AuthorId),
    CONSTRAINT FK_ArticleAuthors_Article FOREIGN KEY (ArticleId) REFERENCES Articles(Id) ON DELETE CASCADE,
    CONSTRAINT FK_ArticleAuthors_Author FOREIGN KEY (AuthorId) REFERENCES Authors(Id) ON DELETE CASCADE
);

CREATE INDEX IX_Articles_JournalId ON Articles(JournalId);

CREATE INDEX IX_ArticleAuthors_ArticleId ON ArticleAuthors(ArticleId);
CREATE INDEX IX_ArticleAuthors_AuthorId ON ArticleAuthors(AuthorId);

CREATE UNIQUE INDEX IX_Journals_ISSN ON Journals(ISSN);