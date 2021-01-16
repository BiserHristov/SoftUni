CREATE DATABASE Hotel
GO

CREATE TABLE Employees  
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
Title NVARCHAR(20),
Notes NVARCHAR(2000)
)

INSERT INTO Employees VALUES
('Pesho', 'Peshev', NULL,'PeshnoNotes'),
('Ivan', 'Petrov', 'CTO','IvanNotes'),
('Kiril', 'Stoyanov', 'Finance Director',NULL)


CREATE TABLE Customers  
(
Id INT PRIMARY KEY IDENTITY,
AccountNumber INT NOT NULL,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
PhoneNumber VARCHAR(20),
EmergencyName NVARCHAR(20) NOT NULL,
EmergencyNumber VARCHAR(20),
Notes NVARCHAR(2000)
)

INSERT INTO Customers VALUES
(12345678, 'Mariya',' Ivanova', '0878111111', 'Penka', '0878222222', 'mariyaNotes'),
(87654321, 'Kalinka','Milusheva', '0878333333', 'Stoyan', '0878444444', 'KalinkaNotes'),
(13243875, 'Ivanka','Petrova', '0878555555', 'Ivan', '0878666666', 'IvankaNotes')



CREATE TABLE RoomStatus  
(
Id INT PRIMARY KEY IDENTITY,
RoomStatus VARCHAR(15) NOT NULL,
Notes NVARCHAR(2000)
)

INSERT INTO RoomStatus VALUES
('free','Smoking room'),
('occupied','NON smoking room'),
('cleaning',NULL)


CREATE TABLE RoomTypes   
(
Id INT PRIMARY KEY IDENTITY,
RoomType VARCHAR(15) NOT NULL,
Notes NVARCHAR(2000)
)

INSERT INTO RoomTypes VALUES
('single','Smoking room'),
('double','NON smoking room'),
('apartment',NULL)


CREATE TABLE BedTypes   
(
Id INT PRIMARY KEY IDENTITY,
BedType VARCHAR(15) NOT NULL,
Notes NVARCHAR(2000)
)

INSERT INTO BedTypes VALUES
('french','Smoking room'),
('doubled','with ladder'),
('casual',NULL)
--RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
CREATE TABLE Rooms   
(
RoomNumber INT PRIMARY KEY,
RoomType INT NOT NULL,
BedType INT NOT NULL,
Rate DECIMAL(5,2),
RoomStatus VARCHAR(15),
Notes NVARCHAR(2000)
)

INSERT INTO Rooms VALUES
(205, 1,3,150.50,2, 'noNOtes'),
(312, 2,1,90,1, NULL),
(133, 3,2,450.50,3, 'my new notes')

--, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, 
--TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes
CREATE TABLE Payments    
(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT NOT NULL,
PaymentDate DATETIME NOT NULL,
AccountNumber INT NOT NULL,
FirstDateOccupied DATETIME NOT NULL,
LastDateOccupied DATETIME NOT NULL,
TotalDays AS DATEDIFF(day, FirstDateOccupied, LastDateOccupied),
AmountCharged DECIMAL(6,2),
TaxRate DECIMAL(5,2),
TaxAmount DECIMAL(10,2),
PaymentTotal AS AmountCharged + TaxRate +TaxAmount,
Notes NVARCHAR(2000)
)

INSERT INTO Payments VALUES
(3,'2020-01-15',12345678,'2020-01-01','2020-01-15', 450.20, 5, 20,NULL),
(2,'2020-02-17',12345678,'2020-01-28','2020-02-17', 660.20, 9, 26,NULL),
(1,'2020-03-22',12345678,'2020-02-25','2020-03-22', 990.80, NULL, 20,NULL)

CREATE TABLE Occupancies     
(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT NOT NULL,
DateOccupied DATETIME NOT NULL,
AccountNumber INT NOT NULL,
RoomNumber INT NOT NULL,
RateApplied DECIMAL(10,2),
PhoneCharge DECIMAL(10,2),
Notes NVARCHAR(2000)
)

INSERT INTO Occupancies VALUES
( 2,'2020-09-16',12345678,205,110.20,20,NULL),
( 3,'2020-08-11',87654321,306,78.20,5,NULL),
( 1,'2020-07-01',12345123,112,950.66,NULL,NULL)