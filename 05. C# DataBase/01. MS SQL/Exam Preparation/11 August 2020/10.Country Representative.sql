
SELECT CountryName,DistributorName FROM 
(
SELECT 
	c.Name AS CountryName, 
	d.Name AS DistributorName,
	COUNT(*) AS TotalCount,
	DENSE_RANK() OVER (PARTITION  BY c.Name ORDER BY COUNT(i.Id) DESC) AS Ranked
FROM Countries c
JOIN Distributors d ON d.CountryId=c.Id
JOIN Ingredients i ON i.DistributorId=d.Id
GROUP BY c.Name, d.Name
) AS t
WHERE t.Ranked=1
ORDER BY CountryName, DistributorName