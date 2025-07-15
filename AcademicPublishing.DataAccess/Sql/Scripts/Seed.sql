INSERT INTO Journals (Name, ISSN, Publisher)
VALUES 
('Journal of Science', '1234-5678', 'SciencePub'),
('Journal of Sports', '8765-4321', 'SportsPub'),
('Journal of Psychology', '8767-4321', 'PsychologyPub');

INSERT INTO Authors (FirstName, LastName, Affiliation)
VALUES 
('Alice', 'Smith', 'Aalborg University'),
('Bob', 'Jones', 'Copenhagen University'),
('Yzeir', 'Baku', 'Abdullah Gul University');

INSERT INTO Articles (Title, Abstract, PublicationDate, JournalId)
VALUES 
('Pool', 'A deep dive into the amazing sport of pool...', '2022-01-01', 1),
('Languages', 'Learning foreign languages and benefits that come along...', '2023-01-01', 2),
('Habits', 'Breaking bad habits...', '2024-01-01', 2),
('Cultures', 'Working with people from different cultures can be...', '2025-01-01', 3);

INSERT INTO ArticleAuthors (ArticleId, AuthorId)
VALUES 
(1, 3), -- (Pool, Yzeir)
(2, 2), -- (Languages, Bob)
(2, 3), -- (Languages, Yzeir)
(3, 1), -- (Habits, Alice)
(4, 1), -- (Cultures, Alice)
(4, 2), -- (Cultures, Bob)
(4, 3); -- (Cultures, Yzeir)