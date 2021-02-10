SELECT t.JobId, ISNULL(SUM(t.CurrentSum), 0.00)AS Total FROM 
(
SELECT j.JobId, p.Price, op.Quantity*p.Price AS CurrentSum   FROM Jobs j
	LEFT JOIN Orders o ON j.JobId=o.JobId
	LEFT JOIN OrderParts op ON op.OrderId=o.OrderId
	LEFT JOIN Parts p ON p.PartId=op.PartId
	WHERE j.Status='Finished'
) AS t
	GROUP BY t.JobId
	ORDER BY SUM(t.CurrentSum) DESC, t.JobId
