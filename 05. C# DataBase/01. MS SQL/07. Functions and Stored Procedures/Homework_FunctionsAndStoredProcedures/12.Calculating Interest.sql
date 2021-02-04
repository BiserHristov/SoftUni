CREATE PROCEDURE usp_CalculateFutureValueForAccount (@accountID INT, @interesteRate DECIMAL (18,4))
AS
SELECT 
a.Id AS [Account Id], 
FirstName AS [First Name], 
LastName AS [Last Name], 
Balance AS [Current Balance],
dbo.ufn_CalculateFutureValue(Balance, @interesteRate, 5)
FROM Accounts a
JOIN AccountHolders ah ON ah.Id=a.AccountHolderId
WHERE a.Id=@accountID


EXEC usp_CalculateFutureValueForAccount 1,0.1