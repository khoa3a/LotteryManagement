USE [LotteryManagement]
GO

--truncate table SouthMonday
--truncate table SouthTuesday
--truncate table SouthWednesday
--truncate table SouthThursday
--truncate table SouthFriday
truncate table SouthSaturday
truncate table SouthSunday

select * from SouthMonday nolock
select * from SouthTuesday nolock
select * from SouthWednesday
select * from SouthThursday
select * from SouthFriday
select * from SouthSunday
select * from SouthSaturday

ALTER TABLE SouthSunday ADD Sub1 VARCHAR(2);
ALTER TABLE SouthSunday ADD Sub2 VARCHAR(2);
ALTER TABLE SouthSunday ADD Sub3 VARCHAR(2);

ALTER TABLE SouthMonday ADD Sub1 VARCHAR(2);
GO
ALTER TABLE SouthMonday ADD Sub2 VARCHAR(2);
GO

update SouthSunday set SubNumber = RIGHT(RTRIM(Number), 2)
update SouthSunday set Sub3 = RIGHT(RTRIM(Number), 1)
update SouthSunday set Sub2 = SUBSTRING(SubNumber, 1, 1)

update SouthMonday set Sub2 = RIGHT(RTRIM(Number), 1)
update SouthMonday set Sub1 = SUBSTRING(SubNumber, 1, 1)



SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthSunday
GROUP BY SubNumber, [Name] having [Name] = N'Tiền Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthSunday
GROUP BY Sub2, [Name] having [Name] = N'Tiền Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub3, COUNT(*) AS Frequency, [Name]
FROM SouthSunday
GROUP BY Sub3, [Name] having [Name] = N'Tiền Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency, [Name]
FROM SouthSunday
GROUP BY Sub2, [Name] having [Name] = N'Kiên Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub3, COUNT(*) AS Frequency, [Name]
FROM SouthSunday
GROUP BY Sub3, [Name] having [Name] = N'Kiên Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub1, COUNT(*) AS Frequency, [Name]
FROM SouthSunday
GROUP BY SubNumber, [Name] having [Name] = N'Kiên Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
--FROM SouthMonday
--FROM SouthTuesday
--FROM SouthWednesday
--FROM SouthThursday
--FROM SouthFriday
--FROM SouthSaturday
FROM SouthSunday
--GROUP BY SubNumber, [Name] having [Name] = 'TP. HCM'
--GROUP BY SubNumber, [Name] having [Name] = N'Bến Tre'
--GROUP BY SubNumber, [Name] having [Name] = N'Đồng Nai'
--GROUP BY SubNumber, [Name] having [Name] = N'An Giang'
--GROUP BY SubNumber, [Name] having [Name] = N'Vĩnh Long'
--GROUP BY SubNumber, [Name] having [Name] = N'Hậu Giang'
GROUP BY SubNumber, [Name] having [Name] = N'Tiền Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
--FROM SouthMonday
--FROM SouthTuesday
--FROM SouthWednesday
--FROM SouthThursday
--FROM SouthFriday
--FROM SouthSaturday
FROM SouthSunday
--GROUP BY SubNumber, [Name] having [Name] = N'Đồng Tháp'
--GROUP BY SubNumber, [Name] having [Name] = N'Cần Thơ'
--GROUP BY SubNumber, [Name] having [Name] = N'Bình Thuận'
--GROUP BY SubNumber, [Name] having [Name] = N'Bình Dương'
--GROUP BY SubNumber, [Name] having [Name] = N'Bình Phước'
--GROUP BY SubNumber, [Name] having [Name] = N'Vũng Tàu'
GROUP BY SubNumber, [Name] having [Name] = N'Kiên Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
--FROM SouthMonday
--FROM SouthTuesday
--FROM SouthWednesday
--FROM SouthThursday
--FROM SouthFriday
--FROM SouthSaturday
FROM SouthSunday
--GROUP BY SubNumber, [Name] having [Name] = N'Cà Mau'
--GROUP BY SubNumber, [Name] having [Name] = N'Sóc Trăng'
--GROUP BY SubNumber, [Name] having [Name] = N'Tây Ninh'
--GROUP BY SubNumber, [Name] having [Name] = N'Trà Vinh'
--GROUP BY SubNumber, [Name] having [Name] = N'Long An'
GROUP BY SubNumber, [Name] having [Name] = N'Đà Lạt'
--GROUP BY SubNumber, [Name] having [Name] = N'Bạc Liêu'
ORDER BY Frequency DESC;
GO

--
SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthSaturday
GROUP BY SubNumber, [Name] having [Name] = N'Hậu Giang'
ORDER BY Frequency DESC;
GO