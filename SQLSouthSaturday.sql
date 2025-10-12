USE [LotteryManagement]
GO

ALTER TABLE SouthSaturday ADD Sub1 VARCHAR(2);
GO
ALTER TABLE SouthSaturday ADD Sub2 VARCHAR(2);
GO

update SouthSaturday set Sub2 = RIGHT(RTRIM(Number), 1)
update SouthSaturday set Sub1 = SUBSTRING(SubNumber, 1, 1)

--truncate table SouthSaturday

select * from SouthSaturday nolock
order by DateKey

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthSaturday
GROUP BY Sub1, [Name] having [Name] = N'TP. HCM'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthSaturday
GROUP BY Sub2, [Name] having [Name] = N'TP. HCM'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthSaturday
GROUP BY Sub1, [Name] having [Name] = N'Long An'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthSaturday
GROUP BY Sub2, [Name] having [Name] = N'Long An'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthSaturday
GROUP BY Sub1, [Name] having [Name] = N'Bình Phước'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthSaturday
GROUP BY Sub2, [Name] having [Name] = N'Bình Phước'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthSaturday
GROUP BY Sub1, [Name] having [Name] = N'Hậu Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthSaturday
GROUP BY Sub2, [Name] having [Name] = N'Hậu Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthSaturday
GROUP BY SubNumber, [Name] having [Name] = N'TP. HCM'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthSaturday
GROUP BY SubNumber, [Name] having [Name] = N'Long An'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthSaturday
GROUP BY SubNumber, [Name] having [Name] = N'Bình Phước'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthSaturday
GROUP BY SubNumber, [Name] having [Name] = N'Hậu Giang'
ORDER BY Frequency DESC;
GO