USE [LotteryManagement]
GO

SELECT [Id]
      ,[DateKey]
      ,[Number]
      ,[Name]
      ,[Sub2Number]
      ,[Sub3Number]
      ,[Sub4Number]
      ,[Sub1]
      ,[Sub2]
      ,[Sub3]
      ,[Sub4]
  FROM [dbo].[NorthTuesday]

GO

select * from SouthWednesday

select * from North where len(number)=3
order by Date desc

update North set sub2=sub1, sub3=sub2, sub4=sub3 where Sub4 is null

update North set sub1=null where Sub4number is null and Sub1 is not null
update North set sub2=null where Sub3number is null and Sub4number is null and Sub2 is not null

select * from north nolock
order by Date desc
where Sub4number is null

delete from North where Date>'2025-11-03 01:00:18.063'

--truncate table SouthWednesday

select sub4number from NorthTuesday where Sub4Number is not null

SELECT TOP 100 sub4number, COUNT(*) AS Frequency, Datekey
FROM NorthTuesday
GROUP BY sub4number, Datekey 
HAVING Sub4Number is not null and (Sub4Number like '%09' or Sub4Number like '%90')
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub1, COUNT(*) AS Frequency
FROM NorthTuesday
GROUP BY Sub1 
HAVING Sub1 is not null
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub2, COUNT(*) AS Frequency
FROM NorthTuesday
GROUP BY Sub2 
HAVING Sub2 is not null
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub3, COUNT(*) AS Frequency
FROM NorthTuesday
GROUP BY Sub3 
HAVING Sub3 is not null
ORDER BY Frequency DESC;
GO

SELECT TOP 5 Sub4, COUNT(*) AS Frequency
FROM NorthTuesday
GROUP BY Sub4 
HAVING Sub4 is not null
ORDER BY Frequency DESC;
GO

SELECT TOP 100 sub4number, COUNT(*) AS Frequency, Datekey
FROM NorthThursday
GROUP BY sub4number, Datekey 
HAVING Sub4Number is not null-- and (Sub4Number like '%09' or Sub4Number like '%90')
ORDER BY Frequency DESC;
GO


SELECT TOP 100 sub3number, COUNT(*) AS Frequency, Datekey
FROM NorthThursday
GROUP BY sub3number, Datekey 
HAVING Sub3Number is not null-- and (Sub4Number like '%09' or Sub4Number like '%90')
ORDER BY Frequency DESC;
GO


select * from North order by date desc

--delete from north where id>49275