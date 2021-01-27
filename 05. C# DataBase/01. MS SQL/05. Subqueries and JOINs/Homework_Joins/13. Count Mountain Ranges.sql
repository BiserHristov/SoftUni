SELECT co.CountryCode, k.MountainCount FROM 
	(
	SELECT c.CountryCode, COUNT(m.MountainRange) AS MountainCount FROM Countries c
		JOIN MountainsCountries mc ON mc.CountryCode=c.CountryCode
		JOIN Mountains m ON m.Id=mc.MountainId
		GROUP BY c.CountryCode
	) AS k
JOIN Countries co ON co.CountryCode=k.CountryCode
WHERE co.CountryName IN ('Bulgaria', 'Russia', 'United States')






--Another solution with nested SELECT:

--SELECT c.CountryCode, 
--(SELECT COUNT(mc.CountryCode) FROM MountainsCountries mc WHERE c.CountryCode=mc.CountryCode) AS MountainRanges 
--FROM Countries c
--WHERE c.CountryName IN ('Bulgaria','Russia','United States')