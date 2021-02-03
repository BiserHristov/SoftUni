CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS NVARCHAR(50)
AS
BEGIN
	DECLARE @result NVARCHAR(50);
 
		IF( @salary<30000) 
			SET @result='Low'
		ELSE IF( @salary<=50000) 
			SET @result='Average'
		ElSE IF( @salary>50000) 
			SET @result='High'
		
		RETURN @result;
END 


--SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level] FROM Employees

