SELECT 
	a.Id, 
	a.Email, 
	c.[Name],COUNT(*) AS Trips 
FROM Accounts a
	JOIN AccountsTrips at ON at.AccountId=a.Id
	JOIN Trips t ON t.Id=at.TripId
	JOIN Rooms r ON r.Id=t.RoomId
	JOIN Hotels h ON h.Id=r.HotelId
	JOIN Cities c ON c.Id=h.CityId
WHERE a.CityId=c.Id
GROUP BY a.Id, a.Email, c.[Name]
ORDER BY Trips DESC, a.Id