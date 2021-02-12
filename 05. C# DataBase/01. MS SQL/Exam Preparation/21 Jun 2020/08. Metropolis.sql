SELECT  TOP(10) 
	a.CityId,
	c.[Name], 
	c.CountryCode AS Country,
	COUNT(*) AS Accounts 
FROM Cities c
	JOIN Accounts a ON a.CityId=c.Id
	GROUP BY a.CityId, 	c.[Name], c.CountryCode
	ORDER BY Accounts DESC