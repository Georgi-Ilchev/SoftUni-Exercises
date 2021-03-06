SELECT j.JobId,
	   ISNULL(SUM(p.Price * op.Quantity), 0) AS TotalOrder
FROM Jobs j
LEFT JOIN Orders o ON o.JobId = j.JobId
LEFT JOIN OrderParts op ON op.OrderId = o.OrderId
LEFT JOIN Parts p ON p.PartId = op.PartId
WHERE [Status] = 'Finished'
GROUP BY j.JobId
ORDER BY TotalOrder DESC, j.JobId ASC