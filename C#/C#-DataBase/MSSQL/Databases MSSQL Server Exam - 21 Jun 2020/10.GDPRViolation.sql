SELECT 
	t.Id, 
	a.FirstName + ' ' + ISNULL(a.MiddleName + ' ', '') + a.LastName AS [Full Name],
	c.[Name] AS [From],
	hc.[Name] AS [To],
	CASE
		WHEN CancelDate IS NULL
		THEN CONVERT(NVARCHAR, DATEDIFF(DAY, ArrivalDate, ReturnDate)) + ' days'
		ELSE 'Canceled' END AS Duration
FROM AccountsTrips [at]
JOIN Accounts a ON [at].AccountId = a.Id
JOIN Trips t ON [at].TripId = t.Id
JOIN Cities c ON a.CityId = c.Id
JOIN Rooms r ON t.RoomId = r.Id
JOIN Hotels h ON r.HotelId = h.Id
JOIN Cities hc ON h.CityId = hc.Id 
ORDER BY [Full Name], t.Id