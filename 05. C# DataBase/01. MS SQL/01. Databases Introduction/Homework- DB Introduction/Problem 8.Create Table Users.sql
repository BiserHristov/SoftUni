--Using SQL query create table Users with columns:
--•	Id – unique number for every user. There will be no more than 2^63-1 users. (Auto incremented)
--•	Username – unique identifier of the user will be no more than 30 characters (non Unicode). (Required)
--•	Password – password will be no longer than 26 characters (non Unicode). (Required)
--•	ProfilePicture – image with size up to 900 KB. 
--•	LastLoginTime
--•	IsDeleted – shows if the user deleted his/her profile. Possible states are true or false.
--Make Id primary key. Populate the table with exactly 5 records. Submit your CREATE and INSERT statements as Run queries & check DB.

CREATE TABLE Users
(
Id BIGINT PRIMARY KEY IDENTITY,
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARCHAR(MAX),
LastLoginTime DATETIME,
IsDeleted BIT
)

INSERT INTO Users ( Username, [Password], ProfilePicture, LastLoginTime, IsDeleted ) VALUES
('user1', 'user1pass','https://krazykillers.files.wordpress.com/2014/07/baumeister.jpg','1980-06-12', 0),
('user2', 'user2pass','https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSSsTyBTbID3yS8BCdxNpJZHCUY6II1X6fZJA&usqp=CAU', '1954-01-19',1),
('user3', 'user3pass','https://futuristspeaker.com/wp-content/uploads/2019/03/futurist-speaker-thomas-frey-do-we-have-a-fake-people-problem-2.jpg','1970-08-12', 0),
('user4', 'user4pass','https://qodebrisbane.com/wp-content/uploads/2019/07/This-is-not-a-person-10-1.jpeg','1980-01-01',0),
('user5', 'user5pass','https://cdn.arteza.com/files/20/02/5KSiFG5hg8nwgz9b.jpg', '1990-12-24',1)

