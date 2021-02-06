
SELECT FirstName + ' ' + LastName AS Available
FROM Mechanics m
	LEFT JOIN Jobs j ON m.MechanicId = j.MechanicId
	WHERE Status IS NULL OR m.MechanicId NOT IN 
		(SELECT m.MechanicId
		FROM Mechanics m
		LEFT JOIN Jobs j ON m.MechanicId = j.MechanicId
		WHERE Status !='Finished'
		GROUP BY m.MechanicId)
	GROUP BY m.MechanicId, FirstName, LastName
	ORDER BY m.MechanicId
	
