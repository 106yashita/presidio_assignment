select * from Categories
select * from Suppliers

select CategoryId from Categories where CategoryName = 'Confections'

--All the products from 'Confections'
select * from products where CategoryID = 
(select CategoryId from Categories where CategoryName = 'Confections')

select * from Suppliers
--select product names from the supplier Tokyo Traders
select ProductName from Products where SupplierID = 
(select SupplierID from Suppliers where CompanyName = 'Tokyo Traders')

--get all the products that are supplied by suppliers from USA

select ProductName from products where SupplierID in 
(select SupplierID from Suppliers where Country = 'USA')

--get all the products from the category that has 'ea' in the description
select ProductName from products where CategoryID in
(select CategoryID from Categories where Description like '%ea%')

select * from customers
--select the product id and the quantity ordered by customrs from France
select ProductID , Quantity from [Order Details] where OrderID in
(select OrderID  from Orders where CustomerID in
(select CustomerID from Customers where Country='France'))

--Get the products that are priced above the average price of all the products
select * from products where UnitPrice > (select AVG(UnitPrice) from Products)

select * from [Order Details]
select employeeID, MAX(OrderDate) from Orders group by EmployeeID

--Select the lastet order by every employee
--select * from Orders where orderdate in 
--(select distinct Max(OrderDate) from orders group by Employeeid)
select * from orders o1
where orderdate = 
(select max(orderdate) from orders o2
where o2.EmployeeID = o1.employeeid)
order by o1.EmployeeID

--Select the maximum priced product in every category
select * from products p1 where UnitPrice =
(select max(UnitPrice) from Products p2 where p1.CategoryID = p2.CategoryID)

select * from orders

--select the order number for the maximum fright paid by every customer
select * from orders o1 where Freight = 
(select max(Freight) from Orders o2 where o1.EmployeeID=o2.EmployeeID) order by o1.EmployeeID

--cross join
select * from Customers,Categories

--Inner join
select * from categories where CategoryID 
not in (select distinct categoryid from products)

select * from Suppliers where SupplierID 
not in (select distinct SupplierID from products)

--Get teh categoryId and teh productname
select CategoryId,ProductName from products

--Get teh categoryname and the productname
select categoryName,ProductName from Categories 
join Products on Categories.CategoryID = Products.CategoryID

--Get the Supplier company name, contact person name, Product name and the stock ordered
select CompanyName,ContactName,ProductName,UnitsOnOrder 
from Suppliers join Products on Suppliers.SupplierID=Products.SupplierID
order by UnitsOnOrder

 --Print the order id, customername and the fright cost for all teh orders
select OrderID,contactName,Freight from Orders o
join Customers c on c.CustomerID = o.CustomerID
 
 --product name, quantity sold, Discount Price, Order Id, Fright for all orders
 select o.OrderID "Order ID",p.Productname, od.Quantity "Quantity Sold",
 (p.UnitPrice*od.Quantity) "Base Price", 
 ((p.UnitPrice*od.Quantity)-((p.UnitPrice*od.Quantity)* od.Discount/100)) "Discounted price",
 Freight "Freight Charge"
 from Orders o join [Order Details] od
 on o.OrderID = od.OrderID
 join Products p on p.ProductID = od.ProductID
 order by o.OrderID

 --select customer name, product name, quantity sold and the frieght, 
 --total price(unitpice*quantity+freight)
 select c.ContactName,p.Productname ,od.Quantity "Quantity Sold",
o.Freight "Freight Charge", (p.UnitPrice*od.Quantity + o.Freight) "Total Price"
 from Orders o join [Order Details] od
on o.OrderID=od.OrderID
join Products p on p.ProductID = od.ProductID
join customers c on c.customerID = o.CustomerID

--Print the product name and the total quantity sold
 select productName,sum(quantity) "Total quantity sold"
 from products p join [Order Details] od
 on p.ProductID = od.ProductID
 group by ProductName
 order by 2 desc

select o.OrderID ,c.ContactName, count(ProductID) 
from [Order Details] od join Orders o on o.OrderID=od.OrderID 
join Customers c on o.CustomerID=c.CustomerID
group by o.OrderID,c.ContactName

select e.FirstName , c.ContactName , p.ProductName, sum(od.UnitPrice* od.Quantity) as totalPrice from 
Employees e join Orders o on o.EmployeeID=e.EmployeeID 
join Customers c on c.CustomerID= o.CustomerID join 
[Order Details] od on o.OrderID=od.OrderID join 
Products p on p.ProductID=od.ProductID group by p.ProductName, c.ContactName,e.FirstName;