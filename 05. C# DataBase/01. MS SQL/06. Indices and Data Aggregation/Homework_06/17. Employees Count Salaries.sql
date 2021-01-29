SELECT COUNT(e.Salary) AS [Count] FROM Employees e
LEFT JOIN Employees m ON e.ManagerID=m.EmployeeID
WHERE e.ManagerID IS NULL