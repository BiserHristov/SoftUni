SELECT i.Id,u.UserName+' : ' +i.Title  FROM Issues i
	JOIN Users u ON u.Id=i.AssigneeId 
	ORDER BY i.Id DESC, i.AssigneeId