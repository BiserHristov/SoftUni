SELECT 
	FirstName,
	LastName,	
	FORMAT(BirthDate,'MM-dd-yyyy') AS BirthDate,	
	c.[Name],	
	Email 
FROM Accounts a
JOIN Cities c ON c.Id=a.CityId
WHERE Email LIKE 'e%'
ORDER BY c.Name