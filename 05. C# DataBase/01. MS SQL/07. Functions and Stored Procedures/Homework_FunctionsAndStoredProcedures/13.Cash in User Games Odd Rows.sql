CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE AS
RETURN
(
	SELECT SUM(Cash) AS SumCash FROM 
	(
	SELECT Cash, Name, 
	ROW_NUMBER() OVER (ORDER BY Cash DESC) AS Ranked
	FROM UsersGames ug
		JOIN Games g ON g.Id=ug.GameId 
		WHERE [Name]=@gameName
	
	) AS k
	WHERE k.Ranked%2!=0
)

