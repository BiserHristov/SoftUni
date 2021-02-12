CREATE FUNCTION udf_GetAvailableRoom(@hotelId INT, @date VARCHAR(MAX), @people INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
DECLARE @message VARCHAR(MAX)=(SELECT TOP(1) 'Room '+ CAST(r.Id AS VARCHAR)+ ': ' +r.Type+
' (' + CAST(r.Beds AS VARCHAR)+' beds) - $' + CAST((h.BaseRate+r.Price)*@people AS VARCHAR) FROM Rooms r
	JOIN Trips t ON t.RoomId= r.Id
	JOIN Hotels h ON h.Id=r.HotelId
	WHERE h.Id=@hotelId
			AND NOT EXISTS(SELECT * FROM Trips tr
							WHERE tr.RoomId=r.Id 
							AND CAST('2015-07-26' AS DATE) BETWEEN ArrivalDate AND ReturnDate
							AND tr.CancelDate IS NULL)
					AND r.Beds>=@people
	GROUP BY r.Id,r.Type, r.Beds,(h.BaseRate+r.Price)*@people
	ORDER BY (h.BaseRate+r.Price)*@people DESC)
	
	IF(@message is NULL)
		SET @message= 'No rooms available'
	
	RETURN @message;
	
END

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)