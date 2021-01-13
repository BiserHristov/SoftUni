CREATE TABLE People
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
Picture VARCHAR(MAX),
Height DECIMAL(3,2), 
[Weight] DECIMAL(5,2), 
Gender CHAR(1) NOT NULL,
Birthdate DATETIME NOT NULL,
Biography NVARCHAR(MAX)
)



INSERT INTO People VALUES
('Ivan Petrov','https://krazykillers.files.wordpress.com/2014/07/baumeister.jpg', 1.82, 76.20, 'M','1980-06-12','This is my boring biography'),
('Stefan Ivanov','https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSSsTyBTbID3yS8BCdxNpJZHCUY6II1X6fZJA&usqp=CAU', 1.90, 88.10, 'M','1954-01-19','This is another boring biography'),
('Mariya Sokolova','https://futuristspeaker.com/wp-content/uploads/2019/03/futurist-speaker-thomas-frey-do-we-have-a-fake-people-problem-2.jpg', 1.75, 61.90, 'F','1970-08-12', NULL),
('Kirilka Stoyanova','https://qodebrisbane.com/wp-content/uploads/2019/07/This-is-not-a-person-10-1.jpeg', 1.72, 65.20, 'F','1980-01-01','Very nice person'),
('Nadezhda Petrova','https://cdn.arteza.com/files/20/02/5KSiFG5hg8nwgz9b.jpg', 1.66, 59.60, 'F','1990-12-24',NULL)

