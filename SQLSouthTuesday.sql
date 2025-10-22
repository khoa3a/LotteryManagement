USE [LotteryManagement]
GO

--truncate table SouthTuesday

--
select * from SouthTuesday nolock
order by DateKey

ALTER TABLE SouthTuesday ADD Sub0 VARCHAR(2);


update SouthTuesday set Sub2 = RIGHT(RTRIM(Number), 1)
update SouthTuesday set Sub1 = SUBSTRING(SubNumber, 1, 1)

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthTuesday
GROUP BY Sub1, [Name] having [Name] = N'Bến Tre'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthTuesday
GROUP BY Sub2, [Name] having [Name] = N'Bến Tre'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthTuesday
GROUP BY Sub1, [Name] having [Name] = N'Vũng Tàu'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthTuesday
GROUP BY Sub2, [Name] having [Name] = N'Vũng Tàu'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthTuesday
GROUP BY Sub1, [Name] having [Name] = N'Bạc Liêu'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthTuesday
GROUP BY Sub2, [Name] having [Name] = N'Bạc Liêu'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthTuesday
GROUP BY SubNumber, [Name] having [Name] = N'Bến Tre'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthTuesday
GROUP BY SubNumber, [Name] having [Name] = N'Bạc Liêu'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthTuesday
GROUP BY SubNumber, [Name] having [Name] = N'Vũng Tàu'
ORDER BY Frequency DESC;
GO

select distinct subnumber from SouthTuesday where [Name] = N'Vũng Tàu'
go

select distinct subnumber from SouthTuesday where [Name] = N'Bạc Liêu'
go

select distinct subnumber from SouthTuesday where [Name] = N'Bến Tre'
go