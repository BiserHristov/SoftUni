SELECT s.Name, s.Manufacturer FROM Colonists c
	JOIN TravelCards tc ON tc.ColonistId=c.Id
	JOIN Journeys j ON j.Id=tc.JourneyId
	JOIN Spaceships s ON s.Id=j.SpaceshipId
	WHERE tc.JobDuringJourney='Pilot' AND
	DATEDIFF(YEAR,c.BirthDate,'2019-01-01')<30
	ORDER BY s.Name