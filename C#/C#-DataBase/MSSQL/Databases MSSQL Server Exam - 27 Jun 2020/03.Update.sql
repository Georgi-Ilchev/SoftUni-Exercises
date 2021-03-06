DECLARE @mechanicId INT = (SELECT MechanicId FROM Mechanics WHERE FirstName = 'Ryan')
DECLARE @newStatus VARCHAR(11) = 'In Progress'

UPDATE Jobs
SET MechanicId = @mechanicId, [Status] = @newStatus
WHERE [Status] = 'Pending'