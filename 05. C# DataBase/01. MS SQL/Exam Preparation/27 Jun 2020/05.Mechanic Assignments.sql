SELECT 
	m.FirstName +' '+ m.LastName AS [Mechanic],
	Status,
	IssueDate
FROM Mechanics m
	JOIN Jobs j ON j.MechanicId=m.MechanicId
	ORDER BY m.MechanicId,IssueDate, j.JobId 