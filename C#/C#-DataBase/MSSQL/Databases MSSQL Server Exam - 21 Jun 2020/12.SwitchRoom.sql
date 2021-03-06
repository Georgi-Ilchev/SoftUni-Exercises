CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	DECLARE @tripHotelId INT = (SELECT HotelId FROM Trips t JOIN Rooms r ON t.RoomId = r.Id WHERE t.Id = @TripId);
	DECLARE @targetRoomHotelId INT = (SELECT HotelId FROM Rooms WHERE Id = @TargetRoomId);
		IF(@tripHotelId != @targetRoomHotelId)
		THROW 50001, 'Target room is in another hotel!', 1


	DECLARE @tripAccounts INT = (SELECT COUNT(*) FROM AccountsTrips WHERE TripId = @TripId);
	DECLARE @targetRoomsBeds INT = (SELECT Beds FROM Rooms WHERE Id = @TargetRoomId);
		IF(@tripAccounts > @targetRoomsBeds)
		THROW 50002, 'Not enough beds in target room!', 1

	UPDATE Trips
	SET RoomId = @TargetRoomId
	WHERE Id = @TripId
GO

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10
EXEC usp_SwitchRoom 10, 7
EXEC usp_SwitchRoom 10, 8
