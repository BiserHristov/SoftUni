CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @isCompromised BIT = 1;
	DECLARE @count INT =LEN(@word);
	DECLARE @searchWord NVARCHAR(50) = @word

	WHILE @count > 0
	BEGIN
		IF CHARINDEX(LEFT(@searchWord,1),@setOfLetters)<1
			BEGIN
				SET @isCompromised=0
				BREAK
			END

			SET @searchWord=SUBSTRING(@searchWord,2,LEN(@searchWord))
			SET @count-=1
	END
	RETURN @isCompromised
END









--CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50))
--RETURNS @result TABLE
--(
--SetOfLetters NVARCHAR(50),
--Word NVARCHAR(50),
--Result BIT
--)
--AS
--BEGIN
--	DECLARE @isCompromised BIT = 1;
--	DECLARE @count INT =LEN(@word);
--	DECLARE @searchWord NVARCHAR(50) = @word
--	WHILE @count > 0
--	BEGIN
--		IF CHARINDEX(LEFT(@searchWord,1),@setOfLetters)<1
--			BEGIN
--				SET @isCompromised=0
--				BREAK
--			END

--			SET @searchWord=SUBSTRING(@searchWord,2,LEN(@searchWord))
--			SET @count-=1
--	END
	
--	INSERT INTO @result VALUES(@setOfLetters, @word, @isCompromised)
--	RETURN
--END

--SELECT * FROM dbo.ufn_IsWordComprised ('pppp', 'Guy')