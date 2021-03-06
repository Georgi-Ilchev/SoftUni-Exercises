CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30)) 
RETURNS INT
AS
BEGIN
	DECLARE	@result INT = 
				(SELECT COUNT(*) AS [Count]
				FROM Planets p
				JOIN Spaceports sp ON sp.PlanetId = p.Id
				JOIN Journeys j ON j.DestinationSpaceportId = sp.Id
				JOIN TravelCards tc ON tc.JourneyId = j.Id
				JOIN Colonists c ON c.Id = tc.ColonistId
				WHERE p.Name = @PlanetName)
	
 RETURN @result
END

SELECT dbo.udf_GetColonistsCount('Otroyphus')

