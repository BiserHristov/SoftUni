CREATE OR ALTER PROC usp_GetEmployeesFromTown (@input NVARCHAR(MAX))
AS
SELECT FirstName, LastName FROM Employees e
JOIN Addresses a ON e.AddressID=a.AddressID
JOIN Towns t ON a.TownID=t.TownID
WHERE t.Name= @input
