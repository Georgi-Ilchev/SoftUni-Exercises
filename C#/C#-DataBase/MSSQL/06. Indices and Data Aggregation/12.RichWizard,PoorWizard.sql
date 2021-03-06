SELECT SUM([Difference]) AS SumDifference
FROM (SELECT DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) AS [Difference] 
      FROM WizzardDeposits) AS Diff



SELECT SUM(Guest.DepositAmount - Host.DepositAmount) AS SumDifference
FROM WizzardDeposits AS Host
JOIN WizzardDeposits AS Guest ON Guest.Id + 1 = Host.Id