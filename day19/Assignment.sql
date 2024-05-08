--1) Create a stored procedure that will take the author firstname 
--and print all the books polished by him with the publisher's name

create proc proc_AuthorBook(@cname varchar(20))
as
begin
   select t.title,p.pub_name from authors as a join titleauthor as ta on a.au_id=ta.au_id
   join titles t on ta.title_id=t.title_id 
   join publishers p on t.pub_id=p.pub_id
   where a.au_fname=@cname
end

exec proc_AuthorBook 'Johnson'

--2) Create a sp that will take the employee's firtname and print all the titles
--sold by him/her, price, quantity and the cost.

create proc proc_EmpDetails(@cname varchar(20))
as
begin
   select  t.title,t.price,s.qty, (t.price*s.qty) as cost
   from employee e join titles t on e.pub_id=t.pub_id
   join sales s on t.title_id=s.title_id
   where e.fname=@cname
end

exec proc_EmpDetails 'Paolo'

--3) Create a query that will print all names from authors and employees
select au_fname as name from authors
union
select fname as name from employee

--4) Create a  query that will float the data from sales,titles, publisher
--and authors table to print title name, Publisher's name, author's full name 
--with quantity ordered and price for the order for all orders,
--print first 5 orders after sorting them based on the price of order

select top 5 t.title as Booktitle, p.pub_name,CONCAT(a.au_fname,' ',a.au_lname) as Authorname,
sum(s.qty),sum(t.price*s.qty) as TotalPrice
from sales s join titles t on s.title_id=t.title_id
join publishers p on t.pub_id=p.pub_id
join titleauthor ta on t.title_id=ta.title_id
join authors a on ta.au_id=a.au_id
group by t.title,p.pub_name,CONCAT(a.au_fname,' ',a.au_lname)
order by TotalPrice desc