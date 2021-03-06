SELECT u.Username,
	   AVG(f.Size) AS Size
FROM Users u
JOIN Commits c ON u.Id = c.ContributorId
JOIN Files f ON c.id = f.CommitId
WHERE c.ContributorId IS NOT NULL
GROUP BY u.Username
ORDER BY Size DESC, Username ASC