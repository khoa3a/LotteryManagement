USE [LotteryManagement]
GO

SELECT [Id]
      ,[DateKey]
      ,[Number]
      ,[Name]
      ,[Sub2Number]
      ,[Sub3Number]
      ,[Sub4Number]
      ,[Sub1]
      ,[Sub2]
      ,[Sub3]
      ,[Sub4]
  FROM [dbo].[NorthTuesday]

GO


select sub4number from NorthTuesday where Sub4Number is not null

SELECT TOP 100 sub4number, COUNT(*) AS Frequency, Datekey
FROM NorthTuesday
GROUP BY sub4number, Datekey 
HAVING Sub4Number is not null and (Sub4Number like '%09' or Sub4Number like '%90')
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub1, COUNT(*) AS Frequency
FROM NorthTuesday
GROUP BY Sub1 
HAVING Sub1 is not null
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency
FROM NorthTuesday
GROUP BY Sub2 
HAVING Sub2 is not null
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub3, COUNT(*) AS Frequency
FROM NorthTuesday
GROUP BY Sub3 
HAVING Sub3 is not null
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub4, COUNT(*) AS Frequency
FROM NorthTuesday
GROUP BY Sub4 
HAVING Sub4 is not null
ORDER BY Frequency DESC;
GO

SELECT TOP 100 sub4number, COUNT(*) AS Frequency, Datekey
FROM NorthThursday
GROUP BY sub4number, Datekey 
HAVING Sub4Number is not null-- and (Sub4Number like '%09' or Sub4Number like '%90')
ORDER BY Frequency DESC;
GO


SELECT TOP 100 sub3number, COUNT(*) AS Frequency, Datekey
FROM NorthThursday
GROUP BY sub3number, Datekey 
HAVING Sub3Number is not null-- and (Sub4Number like '%09' or Sub4Number like '%90')
ORDER BY Frequency DESC;
GO
