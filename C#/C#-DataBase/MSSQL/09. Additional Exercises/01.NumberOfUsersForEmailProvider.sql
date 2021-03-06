SELECT
	RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider],
	COUNT(*) AS [Number Of Users]
FROM Users u
GROUP BY RIGHT(Email, LEN(Email) - CHARINDEX('@', Email))
ORDER BY [Number Of Users] DESC, [Email Provider] ASC