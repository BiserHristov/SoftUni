CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS

DECLARE @currentHotelId INT=
(
SELECT HotelId FROM Trips t
JOIN Rooms r ON r.Id=t.RoomId
WHERE t.Id=@TripId
)

DECLARE @targetHotelId INT=
(
SELECT HotelId FROM Rooms
 WHERE Id=@TargetRoomId
)

IF (@currentHotelId!=@targetHotelId)
	THROW 50010,'Target room is in another hotel!',1

DECLARE @currentBeds INT=
(SELECT COUNT(*) FROM AccountsTrips
WHERE TripId=@TripId
)

DECLARE @targetBeds INT=
(SELECT Beds FROM Rooms r
WHERE r.Id=@TargetRoomId
)

IF (@targetBeds<@currentBeds)
THROW 50011,'Not enough beds in target room!',1

UPDATE Trips
SET RoomId=@TargetRoomId
WHERE Id=@TripId


