CREATE FUNCTION dbo.udf_GetColonistsCount(@planetName VARCHAR (30))
RETURNS INT
AS
BEGIN
DECLARE @result INT=(SELECT COUNT(*) FROM Colonists c
	JOIN TravelCards tc ON tc.ColonistId=c.Id
	JOIN Journeys j ON j.Id=tc.JourneyId
	JOIN Spaceports sp ON sp.Id=j.DestinationSpaceportId
	JOIN Planets p ON p.Id=sp.PlanetId
	WHERE p.Name=@planetName)
	RETURN @result
END

SELECT dbo.udf_GetColonistsCount('Otroyphus') AS [Count]