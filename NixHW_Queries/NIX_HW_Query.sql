--1. ��� ���������� ����� ������� ����� �� �������� ��������� �1?

declare @MaxPriceCategoryId int = 1
declare @MaxPrice money = (SELECT MAX(UnitPrice) FROM dbo.Products WHERE CategoryID = @MaxPriceCategoryId )

SELECT ProductName	
FROM dbo.Products
WHERE CategoryID = @MaxPriceCategoryId AND UnitPrice = @MaxPrice

--2. � ����� ������ ������ ��������������� ����� ������ ����?

declare @OrderBatchingDays int = 10

SELECT ShipCity
FROM dbo.Orders
GROUP BY OrderDate, ShippedDate, ShipCity
HAVING DATEDIFF(DAY,OrderDate,ShippedDate) > @OrderBatchingDays

--3. ����� ���������� �� ��� ��� ���� �������� ����� �������?

SELECT CustomerID
FROM dbo.Orders
WHERE ShippedDate IS NULL
ORDER BY CustomerID

--4. �������� ����������� �������� ��������, ���������� �� ������ ���������� �������?

SELECT
	MAX(EmployeesPerformance.[Customers count])
FROM(
	SELECT	
		EmployeeID, 
		COUNT(CustomerID) 'Customers count'	
	FROM dbo.Orders	
	GROUP BY EmployeeID) EmployeesPerformance

--5. ������� ����������� ������� �������� �������� �1 � 1997-�?

declare @EmployeeID int = 1
declare @Year int = 1997
declare @Country nvarchar(50) = 'France'

SELECT 
	COUNT(OrderID)
FROM Orders
WHERE EmployeeID = @EmployeeID AND YEAR(OrderDate) = @Year AND ShipCountry = @Country

--6. � ����� ������� ���� ������, � ������� ���� ���������� ������ ���� �������?

SELECT 
	ShipCountry,
	ShipCity,
	COUNT(ShipCity) 
FROM Orders
WHERE ShippedDate IS NOT NULL
GROUP BY ShipCountry, ShipCity
HAVING COUNT(ShipCity) > 2
ORDER BY ShipCity

--7. ����������� �������� �������, ������� ���� ������� � ���������� ����� 1000 ���� (quantity)?

declare @Quantity int = 1000

SELECT 
	Products.ProductName,
	SUM([Order Details].Quantity)
FROM dbo.[Order Details]
INNER JOIN dbo.Products
	ON [Order Details].ProductID = Products.ProductID
GROUP BY [Order Details].ProductID, Products.ProductName
HAVING SUM([Order Details].Quantity) < @Quantity
ORDER BY [Order Details].ProductID

--8. ��� ����� �����������, ������� ������ ������ � ��������� � ������ ����� (�� � ���, � ������� ��� ���������)?

ALTER FUNCTION dbo.CleanString(@StringToClean AS nvarchar(60))
RETURNS nvarchar(60)
AS
BEGIN
	DECLARE @StrLength int;
	DECLARE @CleanedString nvarchar(60);
	DECLARE @ASCIIChar int;
	DECLARE @position int;
	
	SET @position = 1;	
 
	WHILE @position <= DATALENGTH(@StringToClean)
	BEGIN
		SET @ASCIIChar = ASCII(SUBSTRING(@StringToClean, @position, 1)); 
		SET @CleanedString = CONCAT(@CleanedString , CHAR(@ASCIIChar) );
		SET @position = @position + 1
	END

	RETURN @CleanedString;
END;

SELECT DISTINCT
	Customers.ContactName,
	Customers.City,
	Orders.ShipCity
FROM dbo.Customers
INNER JOIN dbo.Orders
	ON Customers.CustomerID = Orders.CustomerID
WHERE dbo.CleanString(Customers.City) NOT LIKE dbo.CleanString(Orders.ShipCity)

--9. �������� �� ����� ��������� � 1997-� ���� ���������������� ������ ����� ��������, ������� ����?

------------------------#CustomersWithFax
SELECT
	CustomerID,
	Fax
INTO #CustomersWithFax
FROM Customers
WHERE Fax IS NOT NULL

------------------------#OrdersByYear
DECLARE @Year int = 1997

SELECT
	OrderID,
	CustomerID,
	OrderDate
INTO #OrdersByYear
FROM Orders
WHERE YEAR(OrderDate) = @Year

------------------------#OrdersDetailProductsAndCategories
SELECT
	[Order Details].OrderID,
	Products.ProductID,
	Products.CategoryID,
	Categories.CategoryName
INTO #OrdersDetailProductsAndCategories
FROM Products
INNER JOIN Categories
	ON Products.CategoryID = Categories.CategoryID
INNER JOIN [Order Details]
	ON [Order Details].ProductID = Products.ProductID

------------------------
DECLARE @BiggestOrdersQuantity int;

SET @BiggestOrdersQuantity = (SELECT
	MAX(result.count)
FROM
(SELECT
	CategoryID,
	COUNT(CategoryID) 'count'
FROM #CustomersWithFax
INNER JOIN #OrdersByYear
	ON #CustomersWithFax.CustomerID = #OrdersByYear.CustomerID
INNER JOIN #OrdersDetailProductsAndCategories
	ON #OrdersByYear.OrderID = #OrdersDetailProductsAndCategories.OrderID 
GROUP BY CategoryID, CategoryName) result)

SELECT
	CategoryID,
	COUNT(CategoryID) 'count',
	CategoryName
FROM #CustomersWithFax
INNER JOIN #OrdersByYear
	ON #CustomersWithFax.CustomerID = #OrdersByYear.CustomerID
INNER JOIN #OrdersDetailProductsAndCategories
	ON #OrdersByYear.OrderID = #OrdersDetailProductsAndCategories.OrderID 
GROUP BY CategoryID, CategoryName
HAVING COUNT(CategoryID) = @BiggestOrdersQuantity

--10. ������� ����� ������ ������� (�� ����, ���� � Quantit) y������ ������ �������� (���, �������) ������ 1996 ����?

DECLARE @Year int = 1996
DECLARE @MonthStart int = 9
DECLARE @MonthEnd int = 11

SELECT
	Employees.EmployeeID,
	Employees.FirstName,
	Employees.LastName,
	SUM([Order Details].Quantity) Quantity
FROM Employees
INNER JOIN Orders
	ON Employees.EmployeeID = Orders.EmployeeID
INNER JOIN [Order Details]
	ON Orders.OrderID = [Order Details].OrderID
WHERE YEAR(Orders.ShippedDate) = @Year AND 
	MONTH(Orders.ShippedDate) BETWEEN @MonthStart AND @MonthEnd
GROUP BY Employees.EmployeeID, Employees.FirstName, Employees.LastName
