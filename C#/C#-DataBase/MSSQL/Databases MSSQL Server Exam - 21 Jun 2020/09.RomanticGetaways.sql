SELECT 
	AccountId AS Id, 
	Email, 
	c.[Name] AS City, 
	COUNT(*) AS Trips
FROM AccountsTrips [at]
JOIN Accounts a ON a.Id = [at].AccountId
JOIN Cities c ON c.Id = a.CityId
JOIN Trips t ON t.Id = [at].TripId
JOIN Rooms r ON r.Id = t.RoomId
JOIN Hotels h ON h.Id = r.HotelId
WHERE h.CityId = a.CityId
GROUP BY AccountId, Email, c.[Name]
ORDER BY Trips DESC, AccountId
