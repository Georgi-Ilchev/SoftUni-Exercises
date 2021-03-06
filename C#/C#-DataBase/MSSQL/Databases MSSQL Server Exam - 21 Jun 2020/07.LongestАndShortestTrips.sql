SELECT AccountId,
	   a.FirstName + ' ' + a.LastName AS FullName,
	   MAX(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS LongestTrip,
	   MIN(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS ShortestTrip
FROM AccountsTrips [at]
JOIN Accounts a ON a.Id = [at].AccountId
JOIN Trips t ON [at].TripId = t.Id
WHERE MiddleName IS NULL AND CancelDate IS NULL
GROUP BY AccountId, a.FirstName, a.LastName
ORDER BY LongestTrip DESC, ShortestTrip ASC