SELECT COUNT(*) FROM Countries c
LEFT JOIN MountainsCountries mc ON mc.CountryCode=c.CountryCode
WHERE MountainId IS NULL