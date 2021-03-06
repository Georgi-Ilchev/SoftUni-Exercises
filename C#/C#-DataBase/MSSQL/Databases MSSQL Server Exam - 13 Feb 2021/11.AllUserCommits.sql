CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(MAX))
RETURNS INT
AS
BEGIN
	DECLARE @count INT = 
				(SELECT COUNT(*) AS counter
				FROM Users u
				JOIN Commits c ON u.Id = c.ContributorId
				WHERE u.Username = @username)

	RETURN @count
END

