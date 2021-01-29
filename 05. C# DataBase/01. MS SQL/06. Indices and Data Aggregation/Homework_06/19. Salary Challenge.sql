SELECT TOP(10) FirstName,LastName, e.DepartmentID FROM
(
	SELECT DepartmentID, AVG(Salary) AS AverageSalary FROM Employees
	GROUP BY DepartmentID
) AS k
JOIN Employees e ON k.DepartmentID=e.DepartmentID
WHERE Salary > AverageSalary
ORDER BY e.DepartmentID