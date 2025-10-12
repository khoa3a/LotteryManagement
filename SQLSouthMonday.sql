USE [LotteryManagement]
GO

--truncate table SouthMonday

select * from SouthMonday nolock
order by datekey 

update SouthMonday set Sub2 = RIGHT(RTRIM(Number), 1)
update SouthMonday set Sub1 = SUBSTRING(SubNumber, 1, 1)

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthMonday
GROUP BY Sub1, [Name] having [Name] = N'TP. HCM'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthMonday
GROUP BY Sub2, [Name] having [Name] = N'TP. HCM'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthMonday
GROUP BY Sub1, [Name] having [Name] = N'Cà Mau'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthMonday
GROUP BY Sub2, [Name] having [Name] = N'Cà Mau'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthMonday
GROUP BY Sub1, [Name] having [Name] = N'Đồng Tháp'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthMonday
GROUP BY Sub2, [Name] having [Name] = N'Đồng Tháp'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthMonday
GROUP BY SubNumber, [Name] having [Name] = 'TP. HCM'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthMonday
GROUP BY SubNumber, [Name] having [Name] = N'Đồng Tháp'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthMonday
GROUP BY SubNumber, [Name] having [Name] = N'Cà Mau'
ORDER BY Frequency DESC;
GO