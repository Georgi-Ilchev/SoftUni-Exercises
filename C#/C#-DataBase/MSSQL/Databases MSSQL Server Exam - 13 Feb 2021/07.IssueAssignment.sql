SELECT i.Id,
	   u.Username + ' : ' + i.Title AS IssueAssignee
FROM Issues i
LEFT JOIN Users u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, IssueAssignee ASC
