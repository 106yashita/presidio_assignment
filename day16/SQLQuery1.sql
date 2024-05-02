select * from Products

select ProductName, QuantityPerUnit from Products

select ProductName Name_Of_Product, QuantityPerUnit as Quantity_Per_Unit from Products

select ProductName 'Name Of Product', QuantityPerUnit as Quantity_Per_Unit from Products

select * from products where UnitPrice>10

--Select all the products that are out of stock
select * from Products where UnitsInStock=0

--select the products that will no more be stocked
select * from products where Discontinued =1

--Select Products that will be in clearance
select * from products where Discontinued =1 and UnitsInStock>0

--select products that are in teh range of 10 to 30
select * from products where unitprice>10 and unitprice<30
select * from products where unitprice between 10 and 30
--(or)
select * from products where unitprice>=10 and unitprice<=30

select ProductName, UnitPrice Price, UnitsInStock, (UnitPrice*UnitsInStock) "Amount worth"
from products

select ProductName, UnitPrice Price, UnitsInStock, (UnitPrice*UnitsInStock) as "Amount worth"
from products where CategoryID =3

select * from products where QuantityPerUnit like '%boxes%'
select * from products where QuantityPerUnit like '__ boxes'

--Stock of products in category 3

select sum(UnitsInStock) "Stock of products in category 3"
from Products where CategoryID =3

--Avreage price of products supplied by supplier 2
select AVG(UnitPrice) "Avg Price" from Products where SupplierID=2

--Worth of products in order
select sum(UnitsInStock*ReorderLevel) from Products

--Aggr by grouping
--Get the sum of products in stock for every category
select categoryId,sum(UnitsInStock) 'Stock Available' from products
group by CategoryId

--Get the Average price of products supplied by every supplier
select SupplierID, AVG(UnitPrice) as "Avg Price" from Products
group by SupplierID

select supplierID,
count(ProductName) NO_Of_Products,
sum(unitsinstock) 'Items in stock',
avg(unitprice) 'Average PRice'
from products
group by supplierID

select SupplierId, CategoryId, Avg(UnitPrice) Average_Price
from Products
group by CategoryId,SupplierId
having avg(UnitPrice)>15

--Select category ID and Sum of products avaible if the total number of products is 
--greater than 10
select categoryid, sum(productid) 'Total products in the category'
from products
group by categoryid
having sum(productid) > 10

select * from Products order by CategoryID,SupplierID,ProductName

select * from products order by ProductName


select productName,UnitPrice from products
where UnitPrice>15
order by CategoryId

--Get the products sorted by the price. Fetch only those products that will be discontiued
SELECT * FROM Products 
WHERE Discontinued = 1
ORDER BY UnitPrice

--sort by category id and fetch the sum of unit price of products that will not be discontinued
select CategoryId, sum(UnitPrice) 'Total Price'
from Products
where Discontinued != 1
group by CategoryId
order by categoryId

--sort by category id and fetch the sum of unit price of products that will not be discontinued
--select only if the category is having products total price greater than 200
select CategoryId, sum(UnitPrice) 'Total Price'
from Products
where Discontinued != 1
group by CategoryId
Having sum(UnitPrice)>200
order by categoryId desc
--(or)
select CategoryId, sum(UnitPrice) 'Total Price'
from Products
where Discontinued != 1
group by CategoryId
Having sum(UnitPrice)>200
order by 1 desc

--Select the products order by the price in descending order

select * from products order by 6 desc
--(or)
select * from products order by UnitPrice desc

select ProductName,
Rank() over( order by UnitPrice desc) "Price Rank"
from Products


Select * from Customers

