SELECT k.DepartmentID, MAX(k.Salary) FROM
(
SELECT DepartmentID,Salary,
DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) as Ranked
FROM Employees

) AS k
WHERE k.Ranked=3
GROUP BY DepartmentID



--Another Solution:
--SELECT DISTINCT k.DepartmentID, k.Salary FROM
--(
--SELECT DepartmentID,Salary,
--DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) as Ranked
--FROM Employees

--) AS k
--WHERE k.Ranked=3
