SELECT ContinentCode, CurrencyCode, CurrencyCount AS CurrencyUsage
FROM (SELECT ContinentCode, 
			 CurrencyCode, 
			 CurrencyCount,
			 DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyCount DESC) AS CurrencyRank
		FROM (SELECT c.ContinentCode, 
		             c.CurrencyCode, 
					 COUNT(*) AS CurrencyCount
				FROM Countries c
				GROUP BY ContinentCode, CurrencyCode) AS CurrencyCount
				WHERE CurrencyCount > 1) AS CurrencyRanking
WHERE CurrencyRank = 1
ORDER BY ContinentCode




SELECT ContinentCode, CurrencyCode, CurrencyUsage
FROM (SELECT ContinentCode, 
			 CurrencyCode, 
			 COUNT(CurrencyCode) AS CurrencyUsage,
			 DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS Ranked
		FROM Countries
		GROUP BY ContinentCode, CurrencyCode) AS k
WHERE Ranked = 1 AND CurrencyUsage > 1
ORDER BY ContinentCode
