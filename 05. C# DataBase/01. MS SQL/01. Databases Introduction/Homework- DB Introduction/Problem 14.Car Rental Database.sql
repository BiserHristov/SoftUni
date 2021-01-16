CREATE DATABASE CarRental

CREATE TABLE Categories 
(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(20) NOT NULL,
DailyRate DECIMAL(6,2),
WeeklyRate DECIMAL(6,2),
MonthlyRate DECIMAL(6,2),
WeekendRate DECIMAL(6,2)
)

INSERT INTO Categories VALUES
('sedan',10, 5.5, 200,30),
('van',15, 8.5, 300,50),
('truck',20, 10, 400,44)

CREATE TABLE Cars
(
Id INT PRIMARY KEY IDENTITY,
PlateNumber VARCHAR(8) NOT NULL,
Manufacturer VARCHAR(20) NOT NULL,
Model VARCHAR(20) NOT NULL,
CarYear INT NOT NULL,
CategoryId INT ,
Doors INT ,
Picture VARCHAR(200),
Condition VARCHAR(20),
Available BIT
)
INSERT INTO Cars VALUES
('CB1111AB','Ford', 'Focus', 2009,1, 4,'https:\\fordFocus.jpeg', 'used',1),
('CB2222AB','BMW', 'X5', 2012,3, 4,'https:\\bmw.jpeg', 'new',0),
('CB3333AB','Audi', 'A4', 2020,2, 2,'https:\\audi.jpeg', 'new',1)

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
DriverLicenceNumber INT NOT NULL,
FullName NVARCHAR(50) NOT NULL,
[Address] VARCHAR(100) NOT NULL,
City VARCHAR (20),
ZIPCode INT,
Notes NVARCHAR(2000)
)

INSERT INTO Customers VALUES
(12345678, 'Mariya Ivanova', 'Mladost qtr', 'Sofia', NULL, 'mariyaNotes'),
(87654321, 'Kalinka Milusheva', 'Lyulin qtr', 'Sofia', 1777, 'KalinkaNotes'),
(13243875, 'Ivanka Petrova', 'Tsurkva qtr', 'Pernik', 1535, 'IvankaNotes')



CREATE TABLE RentalOrders 
(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT NOT NULL,
CustomerId INT NOT NULL,
CarId INT NOT NULL,
TankLevel DECIMAL(4,2),
KilometrageStart INT NOT NULL,
KilometrageEnd INT NOT NULL,
TotalKilometrage AS KilometrageEnd-KilometrageStart,
StartDate DATETIME NOT NULL,
EndDate DATETIME NOT NULL,
TotalDays AS DATEDIFF(day, StartDate, EndDate),
RateApplied DECIMAL(5,2),
TaxRate DECIMAL(5,2),
OrderStatus VARCHAR(10),
Notes NVARCHAR(2000)

)

INSERT INTO RentalOrders VALUES
(2, 3,1, 20, 8900, 9690,'2020-04-12','2020-05-08' ,580.40,60, 'occupied', 'not so very important notes'),
(1, 2,2, 75, 140000, 152650,'2020-08-01','2020-12-25' ,950.70,80, 'free', NULL),
(3, 1,3, 50.5, 10500, 10700,'2020-01-12','2020-01-14' ,220.60,50, 'occupied', 'very important notes')




