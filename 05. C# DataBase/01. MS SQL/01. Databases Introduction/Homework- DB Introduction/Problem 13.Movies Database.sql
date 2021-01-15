CREATE DATABASE Movies

CREATE TABLE Directors
(
Id INT PRIMARY KEY IDENTITY,
DirectorName NVARCHAR(30) NOT NULL,
Notes NVARCHAR(2000)
)

CREATE TABLE Genres
(
Id INT PRIMARY KEY IDENTITY,
GenreName NVARCHAR(20) NOT NULL,
Notes NVARCHAR(2000)
)

CREATE TABLE Categories 
(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(20) NOT NULL,
Notes NVARCHAR(2000)
)

CREATE TABLE Movies 
(
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(40) NOT NULL,
DirectorId INT NOT NULL,
CopyrightYear INT,
[Length] INT ,
GenreId INT NOT NULL,
CategoryId INT NOT NULL,
Rating DECIMAL(2,1),
Notes NVARCHAR(2000)
)

INSERT INTO Directors VALUES 
('Director1', 'note1'),
('Director2', NULL),
('Director3', 'note3'),
('Director4', 'note4'),
('Director5', NULL)

INSERT INTO Genres VALUES 
('Genre1', 'genreNote1'),
('Genre2', NULL),
('Genre3', 'genreNote3'),
('Genre4', 'genreNote4'),
('Genre5', NULL)

INSERT INTO Categories VALUES 
('Categories1', NULL),
('Categories2', 'categoryNote2'),
('Categories3', 'categoryNote3'),
('Categories4', 'categoryNote4'),
('Categories5', 'categoryNote5')


INSERT INTO Movies VALUES 
('MovieTitle1', 2,'2002', 354, 4,3,5.6,'MovieNote1'),
('MovieTitle2', 5,'2008', 220, 3,5,3,NULL),
('MovieTitle3', 1,'2015', 120, 1,4,8,'MovieNote3'),
('MovieTitle4', 4,'2018', 140, 2,1,9.2,NULL),
('MovieTitle5', 3,'1983', 155, 5,2,6.6,'MovieNote5')

