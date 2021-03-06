CREATE PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(30)) AS

	IF(@JourneyId NOT IN (SELECT j.Id FROM Journeys j))
		THROW 50001, 'The journey does not exist!', 1

	IF((SELECT j.Purpose FROM Journeys j WHERE j.Id = @JourneyId) = @NewPurpose)
		THROW 50002, 'You cannot change the purpose!', 1

	UPDATE Journeys
	SET Purpose = @NewPurpose
	WHERE Id = @JourneyId
GO

EXEC usp_ChangeJourneyPurpose 4, 'Technical'
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'
