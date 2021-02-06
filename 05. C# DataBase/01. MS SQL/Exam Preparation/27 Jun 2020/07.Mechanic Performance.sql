SELECT
	FirstName + ' ' + LastName AS Mechanic,
	AVG(DATEDIFF(DAY, IssueDate, FinishDate)) AS [Average Days]
FROM Mechanics m
	JOIN Jobs j ON j.MechanicId=m.MechanicId
	GROUP BY m.MechanicId,FirstName,LastName
	ORDER BY m.MechanicId
	