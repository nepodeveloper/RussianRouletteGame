-- =============================================
-- Author:		Nepo Ned
-- Create date: 18/01/2023
-- Description:	This sp returns the S&P data mapped to their corresponding indices from datahub for monthly.
-- =============================================

CREATE PROCEDURE pr_GetOrderSummary 
(  @StartDate DATE, 
   @EndDate DATE, 
   @EmployeeID INT = NULL, 
   @CustomerID INT = NULL
 )
AS
BEGIN
		SELECT 
        CONCAT(E.Title_Of_Courtesy, ' ', E.First_Name, ' ', E.Last_Name) AS EmployeeFullName,
        S.Company_Name AS ShipperCompanyName,
        C.Company_Name AS CustomerCompanyName,
        COUNT(DISTINCT O.Order_ID) AS NumberOfOrders,
        --DATEPART(day, O.OrderDate) AS OrderDay,
		(O.Order_Date) AS OrderDay,
        SUM(D.Quantity * D.Unit_Price) AS TotalOrderValue,
        SUM(D.Quantity) AS NumberOfDifferentProducts,
        SUM(D.Quantity * D.Unit_Price * (1 - D.Discount)) AS TotalFreightCost
    FROM 
        Orders O
    LEFT JOIN 
        Employees E ON O.Employee_ID = E.Employee_ID
    LEFT JOIN 
        Customers C ON O.Customer_ID = C.Customer_ID
    LEFT JOIN 
        Shippers S ON O.Ship_Via = S.Shipper_ID
    LEFT JOIN 
        Order_Details D ON O.Order_ID = D.Order_ID	
	WHERE o.OrderDate BETWEEN @StartDate AND @EndDate	
		AND (@EmployeeID IS NULL OR o.EmployeeID = @EmployeeID)
		AND (@CustomerID IS NULL OR o.CustomerID = @CustomerID)
	GROUP BY
		 --DATEPART(DAY, O.OrderDate),
		 O.Order_Date,
	E.Employee_ID,C.Customer_ID, S.Shipper_ID
	ORDER BY 
        OrderDay,
        EmployeeFullName,
        CustomerCompanyName,
        ShipperCompanyName
END

