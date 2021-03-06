-- power point : https://docs.google.com/presentation/d/1k0I7-7RMNXrS8PCxAwgibgbw26OPJfC9O1JTqGOWrN0/edit?usp=sharing

-- database bak link: https://drive.google.com/open?id=1VHhpDiEvy6Los_4wNK843NJqoMzWv80F

-- duplicate table


USE AdventureWorks2017
GO
SELECT * INTO dbo.SalesOrderDetailHeap FROM AdventureWorks2017.Sales.SalesOrderDetail
GO

USE AdventureWorks2017
GO
SELECT * INTO dbo.SalesOrderDetailHeapTest FROM AdventureWorks2017.Sales.SalesOrderDetail
GO


-- noncluster index vs noncluster index with cover index

  CREATE NONCLUSTERED INDEX [Test_nonCluster] ON [AdventureWorks2017].[dbo].[SalesOrderDetailHeapTest]
(
	[CarrierTrackingNumber] ASC
)
INCLUDE ( 	[SalesOrderID]
      ,[SalesOrderDetailID]
	  ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


  CREATE NONCLUSTERED INDEX [Test_nonCluster] ON [AdventureWorks2017].[dbo].[SalesOrderDetail]
(
	[CarrierTrackingNumber] ASC
)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO



SELECT TOP (1000000) [SalesOrderID]
      ,[SalesOrderDetailID]
      ,[CarrierTrackingNumber]
      
  FROM [AdventureWorks2017].[dbo].[SalesOrderDetail] where [CarrierTrackingNumber] = '2E53-4802-85'


  SELECT TOP (1000000) [SalesOrderID]
      ,[SalesOrderDetailID]
      ,[CarrierTrackingNumber]
      
  FROM [AdventureWorks2017].[dbo].[SalesOrderDetailHeapTest] where [CarrierTrackingNumber] = '2E53-4802-85'




  -- non cluster index vs cluster index

    CREATE NONCLUSTERED INDEX [nonCluster] ON [AdventureWorks2017].[dbo].[SalesOrderDetailHeapTest]
(
	[SalesOrderDetailID] ASC
)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


  SELECT TOP (1000000) [SalesOrderID]
      ,[SalesOrderDetailID]
      ,[CarrierTrackingNumber]
      
  FROM [AdventureWorks2017].[dbo].[SalesOrderDetail] where [SalesOrderDetailID] = 51


  SELECT TOP (1000000) [SalesOrderID]
      ,[SalesOrderDetailID]
      ,[CarrierTrackingNumber]
      
  FROM [AdventureWorks2017].[dbo].[SalesOrderDetailHeapTest] where [SalesOrderDetailID] = 51



 
-- composite index vs normal noncluster index


 CREATE NONCLUSTERED INDEX [ix_SalesOrderDetail_composite] ON [AdventureWorks2017].[dbo].[SalesOrderDetailHeapTest]
(
	[ProductID] ASC , [OrderQty] ASC
)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

 CREATE NONCLUSTERED INDEX [ix_SalesOrderDetail_ProductIdOnly] ON [AdventureWorks2017].[dbo].[SalesOrderDetail]
(
	[ProductID] ASC 
)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


  SELECT TOP (1000000) [SalesOrderID]
      ,[SalesOrderDetailID]
      ,[CarrierTrackingNumber]
      
  FROM [AdventureWorks2017].[dbo].[SalesOrderDetail] where [ProductID] = 777 and [OrderQty] = 2


    SELECT TOP (1000000) [SalesOrderID]
      ,[SalesOrderDetailID]
      ,[CarrierTrackingNumber]
      
  FROM [AdventureWorks2017].[dbo].[SalesOrderDetailHeapTest] where [ProductID] = 777 and [OrderQty] = 2



  -- sargable where vs non sargable where

  SELECT TOP (1000000) [SalesOrderID]
      ,[SalesOrderDetailID]
      ,[CarrierTrackingNumber]
      
  FROM [AdventureWorks2017].[dbo].[SalesOrderDetailHeapTest] where [ProductID] = 777 and [OrderQty] = 2

  SELECT TOP (1000000) [SalesOrderID]
      ,[SalesOrderDetailID]
      ,[CarrierTrackingNumber]
      
  FROM [AdventureWorks2017].[dbo].[SalesOrderDetailHeapTest] where [ProductID] + 2 = 775 and [OrderQty] = 2




--bad practice expample 1

  SELECT *
FROM dbo.DonHang
WHERE CONVERT(VARCHAR,OrderDate,103) = '21/08/2009' --cắt bỏ phần thời gian, chỉ giữ lại phần ngày
 
-- or
SELECT *
FROM dbo.DonHang
WHERE DATEPART(d,OrderDate) =21
AND DATEPART(m,OrderDate)=8
AND DATEPART(YEAR,OrderDate)=2009

--good practice expample 1

SELECT *
FROM dbo.DonHang
WHERE OrderDate >= '20090821' AND OrderDate < '20090822'


--bad practice expample 2

SELECT *
FROM dbo.Customer
WHERE SUBSTRING(Ten,1,1) = 'C'
 
--hoặc
SELECT *
FROM dbo.Customer
WHERE LEFT(Ten,1) = 'C'

--good practice expample 1

SELECT *
FROM dbo.Customer
WHERE Ten LIKE 'C%'

--or

SELECT *
FROM dbo.Customer
WHERE Ten LIKE '%C%'



-- page detail example

-- index table vs non index table
SET STATISTICS IO ON
GO
SELECT * FROM SalesOrderDetail WHERE SalesOrderDetailID =75
GO
SELECT * FROM SalesOrderDetailheap WHERE SalesOrderDetailID =75





DBCC IND('AdventureWorks2017','SalesOrderDetail',1)

DBCC traceon(3604)
GO
DBCC page('AdventureWorks2017',1,26216,3) 

DBCC TRACEON(3604)
DBCC PAGE('AdventureWorks2017',1,26216,3) WITH TABLERESULTS
GO
