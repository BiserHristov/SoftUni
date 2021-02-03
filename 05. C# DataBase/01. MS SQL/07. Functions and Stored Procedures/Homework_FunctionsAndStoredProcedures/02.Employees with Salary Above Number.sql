CREATE PROC usp_GetEmployeesSalaryAboveNumber (@input DECIMAL(18,4))
AS
SELECT FirstName, LastName FROM Employees
WHERE Salary>=@input

