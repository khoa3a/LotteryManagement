USE [LotteryManagement]
GO

SELECT [Id]
      ,[DateKey]
      ,[Number]
      ,[Name]
  FROM [dbo].[SouthSaturday]

GO

--truncate table SouthMonday
--truncate table SouthTuesday
--truncate table SouthWednesday
--truncate table SouthThursday
--truncate table SouthFriday
truncate table SouthSaturday
truncate table SouthSunday

select * from SouthMonday 
select * from SouthTuesday
select * from SouthWednesday
select * from SouthThursday
select * from SouthFriday
select * from SouthSunday
select * from SouthSaturday

ALTER TABLE SouthSaturday ADD SubNumber VARCHAR(3);

update SouthSunday set SubNumber = RIGHT(RTRIM(Number), 2)

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
--FROM SouthMonday
--FROM SouthTuesday
--FROM SouthWednesday
--FROM SouthThursday
--FROM SouthFriday
--FROM SouthSaturday
FROM SouthSunday
--GROUP BY SubNumber, [Name] having [Name] = 'TP. HCM'
--GROUP BY SubNumber, [Name] having [Name] = N'Đồng Nai'
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
--GROUP BY SubNumber, [Name] having [Name] = N'TP. HCM'
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
ORDER BY Frequency DESC;
GO

--
SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthSaturday
GROUP BY SubNumber, [Name] having [Name] = N'Bình Phước'
ORDER BY Frequency DESC;
GO