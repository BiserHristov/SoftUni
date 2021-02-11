CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(18,2) AS
BEGIN
	DECLARE @result DECIMAL(18,2)=(SELECT SUM(op.Quantity * p.Price) AS Result FROM Orders o
		JOIN OrderParts op ON op.OrderId=o.OrderId
		JOIN Parts p ON p.PartId=op.PartId
		WHERE o.JobId=@jobId
		GROUP BY JobId)

		IF @result IS NULL 
			SET @result= 0;
		RETURN @result;
END

 