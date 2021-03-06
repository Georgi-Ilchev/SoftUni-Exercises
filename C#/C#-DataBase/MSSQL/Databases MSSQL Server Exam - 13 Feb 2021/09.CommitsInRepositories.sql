SELECT TOP(5) 
	   rc.RepositoryId AS Id,
	   r.[Name],
	   COUNT(*) AS Commits
FROM RepositoriesContributors  rc
JOIN Repositories r ON r.Id = rc.RepositoryId
JOIN Commits c ON r.Id = c.RepositoryId
GROUP BY rc.RepositoryId, r.[Name]
ORDER BY Commits DESC, rc.RepositoryId ASC, r.[Name] ASC

