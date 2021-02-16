CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(MAX))
AS
SELECT  Id,[Name],CAST(Size AS VARCHAR)+'KB' FROM Files
WHERE RIGHT([Name],LEN(@fileExtension))=@fileExtension
ORDER BY Id,[Name],Size DESC


