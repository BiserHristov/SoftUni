SELECT 
	CONCAT(c.FirstName , ' ' , c.LastName )AS CustomerName,
	c.PhoneNumber,
	c.Gender
FROM Customers c
LEFT JOIN Feedbacks f ON c.Id=f.CustomerId
WHERE f.CustomerId IS NULL
ORDER BY c.Id