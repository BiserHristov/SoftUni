CREATE VIEW v_UserWithCountries 
AS
SELECT 
c.FirstName + ' ' + c.LastName AS CustomerName,
c.Age,
c.Gender,
con.Name
FROM Customers c
JOIN Countries con ON con.Id=c.CountryId
