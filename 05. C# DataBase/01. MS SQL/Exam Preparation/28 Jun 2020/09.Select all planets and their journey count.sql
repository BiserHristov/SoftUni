--Extract from the database all planets’ names and their journeys count. 
--Order the results by journeys count, descending and by planet name ascending.

SELECT p.Name ,COUNT(j.Id) FROM Planets p
	JOIN Spaceports sp ON sp.PlanetId=p.Id
	JOIN Journeys j ON j.DestinationSpaceportId=sp.Id
GROUP BY p.Name
ORDER BY COUNT(j.Id) DESC, p.Name 