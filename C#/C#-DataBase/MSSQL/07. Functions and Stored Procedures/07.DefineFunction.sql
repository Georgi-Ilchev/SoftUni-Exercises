CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @index INT = 1
	DECLARE @wordLength INT = LEN(@word);

	WHILE(@index <= @wordLength)
		BEGIN
			DECLARE @symbol VARCHAR(1) = SUBSTRING(@word, @index, 1)

			IF(CHARINDEX(@symbol, @setOfLetters, 1) = 0)
				RETURN 0

			SET @index += 1
		END

		RETURN 1
END

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia'),
       dbo.ufn_IsWordComprised('oistmiahf', 'halves'),
       dbo.ufn_IsWordComprised('bobr', 'Rob'),
       dbo.ufn_IsWordComprised('pppp', 'Guy')