
SELECT SUM(k.Difference) AS TotalSum FROM 
(
SELECT  w1.FirstName AS [Host Wizard], w1.DepositAmount AS[Host Wizard Deposit], 
	    w2.FirstName AS [Guest Wizard], w2.DepositAmount AS[Guest Wizard Deposit],
	   w1.DepositAmount - w2.DepositAmount AS [Difference]
FROM WizzardDeposits w1
JOIN WizzardDeposits w2 ON w1.Id+1=w2.Id
) AS k