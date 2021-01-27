	
SELECT TOP(1) AVG(e.Salary) AS MinAverageSalary FROM Departments d
	JOIN Employees e ON e.DepartmentID=d.DepartmentID
	GROUP BY d.Name
ORDER BY MinAverageSalary



--Solution with DENSE_RANK():

--SELECT MinAverageSalary FROM 
--(
--SELECT AVG(e.Salary) AS MinAverageSalary, 
--DENSE_RANK() OVER (ORDER BY AVG(e.Salary)) AS Ranked FROM Departments d
--	JOIN Employees e ON e.DepartmentID=d.DepartmentID
--	GROUP BY d.Name
--) AS k
--WHERE Ranked=1



--Solution with nested SELECT:

--	SELECT TOP(1) (SELECT AVG(Salary) FROM Employees e WHERE e.DepartmentID= d.DepartmentID) AS MinAverageSalary 
--	FROM Departments d
--	ORDER BY MinAverageSalary

