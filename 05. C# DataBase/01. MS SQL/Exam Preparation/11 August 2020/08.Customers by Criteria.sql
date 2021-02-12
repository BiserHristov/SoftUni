SELECT FirstName,Age,PhoneNumber FROM Customers c
JOIN Countries con ON con.Id=c.CountryId
WHERE (Age>=21 AND FirstName LIKE '%an%') OR
 (RIGHT(PhoneNumber,2)=38 AND con.Name!='Greece')
ORDER BY FirstName, Age DESC
