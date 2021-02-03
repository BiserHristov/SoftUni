CREATE OR ALTER PROC usp_GetTownsStartingWith (@input NVARCHAR(MAX))
AS
SELECT t.Name FROM Towns t
WHERE LEFT(t.Name, LEN(@input))=@input



	--Another solution with SUBSTRING
--CREATE PROC usp_GetTownsStartingWith (@input NVARCHAR(MAX))
--AS
--SELECT t.Name FROM Towns t
--WHERE SUBSTRING(t.Name,1,LEN(@input))=@input




	--Another solution with LIKE
--CREATE PROC usp_GetTownsStartingWith (@input NVARCHAR(MAX))
--AS
--SELECT t.Name FROM Towns t
--WHERE t.Name LIKE @input + '%'