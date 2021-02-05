SELECT JobDuringJourney, FirstName + ' ' + LastName AS FullName, Ranked AS JobRank FROM 
(SELECT c.Id,
	JobDuringJourney, 
	FirstName, 
	LastName,
	BirthDate,
	DATEDIFF(YEAR,BirthDate, GETDATE()) AS Age,
	ROW_NUMBER() OVER(PARTITION BY JobDuringJourney ORDER BY DATEDIFF(HOUR,BirthDate, GETDATE()) DESC) AS Ranked
FROM Colonists c
JOIN TravelCards tc ON tc.ColonistId=c.Id
) AS t
WHERE Ranked=2
