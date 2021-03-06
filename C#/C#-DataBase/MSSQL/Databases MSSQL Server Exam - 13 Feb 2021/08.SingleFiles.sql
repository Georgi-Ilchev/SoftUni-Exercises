SELECT f1.Id,
	   f1.[Name],
	   CONCAT(f1.Size, 'KB') AS Size
FROM Files f1
LEFT JOIN Files f2 ON f2.ParentId = f1.Id
WHERE f2.ParentId IS NULL
ORDER BY Id ASC, [Name] ASC, Size DESC