SELECT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup LIKE 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter


SELECT DISTINCT Left(FirstName, 1) AS FirstLetter 
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
ORDER BY FirstLetter