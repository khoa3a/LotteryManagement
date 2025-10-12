USE [LotteryManagement]
GO

ALTER TABLE SouthWednesday ADD Sub1 VARCHAR(2);
GO
ALTER TABLE SouthWednesday ADD Sub2 VARCHAR(2);
GO

update SouthWednesday set Sub2 = RIGHT(RTRIM(Number), 1)
update SouthWednesday set Sub1 = SUBSTRING(SubNumber, 1, 1)

--truncate table SouthWednesday

--select * from SouthWednesday nolock
select * from SouthWednesday nolock
order by DateKey

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthWednesday
GROUP BY Sub1, [Name] having [Name] = N'Đồng Nai'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthWednesday
GROUP BY Sub2, [Name] having [Name] = N'Đồng Nai'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthWednesday
GROUP BY Sub1, [Name] having [Name] = N'Cần Thơ'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthWednesday
GROUP BY Sub2, [Name] having [Name] = N'Cần Thơ'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthWednesday
GROUP BY Sub1, [Name] having [Name] = N'Sóc Trăng'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthWednesday
GROUP BY Sub2, [Name] having [Name] = N'Sóc Trăng'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthWednesday
GROUP BY SubNumber, [Name] having [Name] = N'Đồng Nai'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthWednesday
GROUP BY SubNumber, [Name] having [Name] = N'Sóc Trăng'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthWednesday
GROUP BY SubNumber, [Name] having [Name] = N'Cần Thơ'
ORDER BY Frequency DESC;
GO