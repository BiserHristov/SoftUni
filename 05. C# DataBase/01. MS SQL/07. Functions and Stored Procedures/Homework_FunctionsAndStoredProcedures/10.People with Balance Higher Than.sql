CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@inputBalance DECIMAL(18,2))
AS
SELECT FirstName, LastName FROM AccountHolders ah
JOIN Accounts a ON a.AccountHolderId=ah.Id
GROUP BY FirstName, LastName
HAVING SUM(Balance)>@inputBalance
ORDER BY FirstName,LastName

EXEC usp_GetHoldersWithBalanceHigherThan 50000