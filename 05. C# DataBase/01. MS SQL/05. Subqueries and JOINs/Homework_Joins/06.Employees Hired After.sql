SELECT  
   e.FirstName,
   e.LastName,
   e.HireDate,
   d.Name AS DeptName
 FROM Employees e
  JOIN Departments d ON e.DepartmentID=d.DepartmentID 
	AND d.Name IN ('Sales', 'Finance')
	AND e.HireDate > '1999-01-01'
 ORDER BY e.HireDate
 
 
