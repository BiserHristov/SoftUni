SELECT 
	t.Id,
	FirstName + ' ' +ISNULL(MiddleName + ' ','') + LastName AS [FullName],
	ca.[Name] AS [From],
	ch.[Name] AS [To],
CASE
	WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
	ELSE CAST(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS VARCHAR) + ' days'
END AS Duration
FROM Trips t
	JOIN AccountsTrips at ON at.TripId=t.Id
	JOIN Accounts acc ON acc.Id= at.AccountId
	JOIN Cities ca ON ca.Id=acc.CityId
	JOIN Rooms r ON r.Id=t.RoomId
	JOIN Hotels h ON h.Id=r.HotelId
	JOIN Cities ch ON ch.Id=h.CityId
ORDER BY FullName, t.Id
	