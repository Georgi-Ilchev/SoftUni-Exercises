CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(20))
AS	
BEGIN

	SELECT Id, 
		   [Name], 
		   CONVERT(VARCHAR,Size) + 'KB' AS Size
	FROM Files
	WHERE [Name] LIKE '%' + @fileExtension + '%'
	ORDER BY Id ASC, [Name] ASC, Size DESC
	
END
