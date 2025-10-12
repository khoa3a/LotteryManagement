USE [LotteryManagement]
GO

ALTER TABLE SouthFriday ADD Sub1 VARCHAR(2);
GO
ALTER TABLE SouthFriday ADD Sub2 VARCHAR(2);
GO

update SouthFriday set Sub2 = RIGHT(RTRIM(Number), 1)
update SouthFriday set Sub1 = SUBSTRING(SubNumber, 1, 1)

--truncate table SouthFriday

select * from SouthFriday nolock
order by DateKey

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthFriday
GROUP BY Sub1, [Name] having [Name] = N'Vĩnh Long'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthFriday
GROUP BY Sub2, [Name] having [Name] = N'Vĩnh Long'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthFriday
GROUP BY Sub1, [Name] having [Name] = N'Bình Dương'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthFriday
GROUP BY Sub2, [Name] having [Name] = N'Bình Dương'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthFriday
GROUP BY Sub1, [Name] having [Name] = N'Trà Vinh'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthFriday
GROUP BY Sub2, [Name] having [Name] = N'Trà Vinh'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthFriday
GROUP BY SubNumber, [Name] having [Name] = N'Vĩnh Long'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthFriday
GROUP BY SubNumber, [Name] having [Name] = N'Trà Vinh'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthFriday
GROUP BY SubNumber, [Name] having [Name] = N'Bình Dương'
ORDER BY Frequency DESC;
GO