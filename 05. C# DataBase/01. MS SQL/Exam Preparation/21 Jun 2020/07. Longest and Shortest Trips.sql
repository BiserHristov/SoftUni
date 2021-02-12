SELECT 
	a.Id, 
	FirstName + ' ' + LastName AS [FullName], 
	MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip,
	MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
FROM Accounts a
	JOIN AccountsTrips at ON at.AccountId=a.Id
	JOIN Trips t ON t.Id=at.TripId
WHERE MiddleName IS NULL AND CancelDate IS NULL
GROUP BY a.Id, FirstName + ' ' + LastName
ORDER BY LongestTrip DESC, ShortestTrip