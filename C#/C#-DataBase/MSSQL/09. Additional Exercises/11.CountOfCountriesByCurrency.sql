SELECT c.CurrencyCode AS CurrencyCode, 
	   c.[Description] AS Currency,
	   COUNT(co.CurrencyCode) AS NumberOfCountries
FROM Countries co
RIGHT JOIN Currencies c ON c.CurrencyCode = co.CurrencyCode
GROUP BY c.CurrencyCode, c.[Description]
ORDER BY NumberOfCountries DESC, Currency ASC



--
SELECT c.CurrencyCode AS CurrencyCode, 
	   c.[Description] AS Currency,
	   COUNT(co.CurrencyCode) AS NumberOfCountries
FROM Currencies c
LEFT JOIN Countries co ON c.CurrencyCode = co.CurrencyCode
GROUP BY c.CurrencyCode, c.[Description]
ORDER BY NumberOfCountries DESC, Currency ASC