USE [LotteryManagement]
GO

ALTER TABLE SouthThursday ADD Sub1 VARCHAR(2);
GO
ALTER TABLE SouthThursday ADD Sub2 VARCHAR(2);
GO

update SouthThursday set Sub2 = RIGHT(RTRIM(Number), 1)
update SouthThursday set Sub1 = SUBSTRING(SubNumber, 1, 1)

--truncate table SouthThursday

--select * from SouthThursday nolock

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthThursday
GROUP BY Sub1, [Name] having [Name] = N'Tây Ninh'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthThursday
GROUP BY Sub2, [Name] having [Name] = N'Tây Ninh'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthThursday
GROUP BY Sub1, [Name] having [Name] = N'An Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthThursday
GROUP BY Sub2, [Name] having [Name] = N'An Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthThursday
GROUP BY Sub1, [Name] having [Name] = N'Bình Thuận'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthThursday
GROUP BY Sub2, [Name] having [Name] = N'Bình Thuận'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthThursday
GROUP BY SubNumber, [Name] having [Name] = N'Tây Ninh'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthThursday
GROUP BY SubNumber, [Name] having [Name] = N'Bình Thuận'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthThursday
GROUP BY SubNumber, [Name] having [Name] = N'An Giang'
ORDER BY Frequency DESC;
GO