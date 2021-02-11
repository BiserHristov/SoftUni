CREATE PROC usp_PlaceOrder(@jobID INT, @serialNumber VARCHAR(50),@quantity INT)
AS

/*
Your task is to create a user defined procedure (usp_PlaceOrder) which accepts job ID, part serial number and  
quantity and creates an order with the specified parameters. 
-If an order already exists for the given job that and the order is not issued (order’s issue date is NULL), 
add the new product to it. 
-If the part is already listed in the order, add the quantity to the existing one.
When a new order is created, set it’s IssueDate to NULL.
*/
IF(@quantity<=0)
	THROW 50012,'Part quantity must be more than zero!',1
DECLARE @isJobExisting INT=(SELECT ISNULL(COUNT(*),0) FROM Jobs
							WHERE JobId=@jobID)
IF (@isJobExisting =0)
	THROW 50013,'Job not found!',1;

DECLARE @isFinished INT=(SELECT COUNT(*) FROM Jobs
						 WHERE JobId=@jobID AND Status='Finished')
IF (@isFinished > 0)
	THROW 50011, 'This job is not active!', 1;


DECLARE @existingPartIDBySerial INT=(SELECT COUNT(PartId) FROM Parts
									WHERE SerialNumber=@serialNumber)
IF(@existingPartIDBySerial=0)
	THROW 50014,'Part not found!',1

	

DECLARE @existingOrderId INT=(SELECT IIF(COUNT(OrderId)>0, FROM Orders
								WHERE JobId=@jobId AND IssueDate IS NULL)

DECLARE @existingPartIDByOrderAndSerial INT=(SELECT ISNULL(p.PartId, 0) FROM OrderParts op
									JOIN Parts p ON op.PartId=p.PartId
									WHERE OrderId=@existingOrderId AND p.SerialNumber=@serialNumber)

IF (@existingOrderId>0)
	INSERT INTO OrderParts VALUES(@existingOrderId, @existingPartIDByOrderAndSerial, @quantity)
 
ELSE IF (@existingPartIDByOrderAndSerial >0)
BEGIN
	UPDATE OrderParts
	SET Quantity+=@quantity
	WHERE OrderId=@existingOrderId AND PartId=@existingPartIDByOrderAndSerial
END

ELSE
BEGIN


	INSERT INTO Orders VALUES (@jobID, NULL,0)
	DECLARE @newOrderId INT =(SELECT OrderId FROM Orders
							WHERE JobId=@jobId AND IssueDate IS NULL AND Delivered=0)
	INSERT INTO OrderParts VALUES (@newOrderId, @existingPartIDByOrderAndSerial,@quantity)
END

