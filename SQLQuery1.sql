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

select * from SouthMonday 
select * from SouthTuesday
select * from SouthWednesday
select * from SouthThursday
select * from SouthFriday
select * from SouthSunday

ALTER TABLE SouthSunday ADD SubNumber VARCHAR(3);

update SouthSunday set SubNumber = RIGHT(RTRIM(Number), 2)

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthMonday
--FROM SouthWednesday
--FROM SouthThursday
--FROM SouthFriday
--FROM SouthSunday
GROUP BY SubNumber, [Name] having [Name] = 'TP. HCM'
--GROUP BY SubNumber, [Name] having [Name] = N'Đồng Nai'
--GROUP BY SubNumber, [Name] having [Name] = N'Đồng Nai'
--GROUP BY SubNumber, [Name] having [Name] = N'Vĩnh Long'
--GROUP BY SubNumber, [Name] having [Name] = N'Tiền Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthMonday
--FROM SouthWednesday
--FROM SouthThursday
--FROM SouthFriday
--FROM SouthSunday
GROUP BY SubNumber, [Name] having [Name] = N'Đồng Tháp'
--GROUP BY SubNumber, [Name] having [Name] = N'Cần Thơ'
--GROUP BY SubNumber, [Name] having [Name] = N'Bình Thuận'
--GROUP BY SubNumber, [Name] having [Name] = N'Bình Dương'
--GROUP BY SubNumber, [Name] having [Name] = N'Kiên Giang'
ORDER BY Frequency DESC;
GO

SELECT TOP 5 SubNumber, COUNT(*) AS Frequency, [Name]
FROM SouthMonday
--FROM SouthWednesday
--FROM SouthThursday
--FROM SouthFriday
--FROM SouthSunday
GROUP BY SubNumber, [Name] having [Name] = N'Cà Mau'
--GROUP BY SubNumber, [Name] having [Name] = N'Sóc Trăng'
--GROUP BY SubNumber, [Name] having [Name] = N'Tây Ninh'
--GROUP BY SubNumber, [Name] having [Name] = N'Trà Vinh'
--GROUP BY SubNumber, [Name] having [Name] = N'Đà Lạt'
ORDER BY Frequency DESC;
GO