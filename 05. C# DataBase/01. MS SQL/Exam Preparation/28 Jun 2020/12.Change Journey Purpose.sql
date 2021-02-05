CREATE PROC usp_ChangeJourneyPurpose (@journeyId INT, @newPurpose VARCHAR(11))
AS
IF NOT EXISTS(SELECT * FROM Journeys WHERE Id=@journeyId )
	THROW 50001, 'The journey does not exist!', 1
ELSE IF (@newPurpose = (SELECT Purpose FROM Journeys WHERE Id=@journeyId))
	THROW 50001, 'You cannot change the purpose!', 1
ELSE
BEGIN
	UPDATE Journeys
	SET Purpose=@newPurpose
	WHERE Id=@journeyId
END