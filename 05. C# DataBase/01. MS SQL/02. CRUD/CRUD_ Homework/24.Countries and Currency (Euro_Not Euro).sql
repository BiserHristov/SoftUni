SELECT CountryName, CountryCode,IIF(CurrencyCode='EUR', 'Euro','Not Euro')  AS Currency FROM Countries
ORDER BY CountryName

SELECT CountryName, CountryCode,
CASE 
   WHEN CurrencyCode='EUR' THEN 'Euro'
   ELSE 'Not Euro' 
END AS Currency FROM Countries
ORDER BY CountryName