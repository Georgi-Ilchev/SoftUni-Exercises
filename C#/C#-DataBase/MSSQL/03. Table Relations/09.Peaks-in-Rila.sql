SELECT Mountains.MountainRange, Peaks.PeakName, Peaks.Elevation
	FROM Peaks
	JOIN Mountains 
		On Peaks.MountainId = Mountains.Id
		WHERE MountainRange = 'Rila'
	ORDER BY Peaks.Elevation DESC
