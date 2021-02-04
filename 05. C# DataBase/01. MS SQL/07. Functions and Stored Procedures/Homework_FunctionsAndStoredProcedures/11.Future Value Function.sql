CREATE FUNCTION ufn_CalculateFutureValue(@sum decimal (18,4), @yearlyInterestRate FLOAT, @years INT)
RETURNS DECIMAL (18,4)
AS
BEGIN
	DECLARE @result DECIMAL (18,4)= POWER((1+@yearlyInterestRate),@years)*@sum
	RETURN @result; 
END
GO


SELECT dbo.ufn_CalculateFutureValue(123.12,0.1,5)