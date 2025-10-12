USE [LotteryManagement]
GO

ALTER TABLE SouthSunday ADD Sub1 VARCHAR(2);
GO
ALTER TABLE SouthSunday ADD Sub2 VARCHAR(2);
GO

update SouthSunday set Sub2 = RIGHT(RTRIM(Number), 1)
update SouthSunday set Sub1 = SUBSTRING(SubNumber, 1, 1)

--truncate table SouthSunday

select * from SouthSunday nolock
order by DateKey

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthSunday
GROUP BY Sub1, [Name] having [Name] = N'Tiền Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthSunday
GROUP BY Sub2, [Name] having [Name] = N'Tiền Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthSunday
GROUP BY Sub1, [Name] having [Name] = N'Kiên Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthSunday
GROUP BY Sub2, [Name] having [Name] = N'Kiên Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthSunday
GROUP BY Sub1, [Name] having [Name] = N'Đà Lạt'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthSunday
GROUP BY Sub2, [Name] having [Name] = N'Đà Lạt'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthSunday
GROUP BY SubNumber, [Name] having [Name] = N'Tiền Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthSunday
GROUP BY SubNumber, [Name] having [Name] = N'Đà Lạt'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthSunday
GROUP BY SubNumber, [Name] having [Name] = N'Kiên Giang'
ORDER BY Frequency DESC;
GO