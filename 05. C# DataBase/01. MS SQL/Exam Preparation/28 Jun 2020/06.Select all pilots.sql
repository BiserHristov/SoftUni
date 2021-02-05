SELECT c.Id AS id, c.FirstName + ' ' + c.LastName AS full_name FROM Colonists c
JOIN TravelCards tc ON tc.ColonistId=c.Id
WHERE JobDuringJourney='Pilot'
ORDER BY c.Id