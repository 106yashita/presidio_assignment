select * from stores
select * from sales
select * from titles
select * from employee
select * from titleauthor
select * from publishers
select * from pub_info
select * from authors
--1) Print the storeid and number of orders for the store
select stor_id, count(ord_num) as "Number of orders" from sales group by stor_id

--2) print the number of orders for every title
select title_id, count(ord_num) as "Number of orders" from sales group by title_id

 --3) print the publisher name and book name
 select t.title,p.pub_name from publishers as p join titles as t on p.pub_id=t.pub_id

 --4) Print the author full name for al the authors
 select CONCAT(au_fname,' ',au_lname) as "Full Name" from authors

 --5) Print the price or every book with tax (price+price*12.36/100)
 select title, (price+price*12.36/100) as "Price"  from titles

 --6) Print the author name, title name
 select a.au_fname as "Name" , t.title 
 from authors as a join titleauthor as ta on a.au_id=ta.au_id 
 join titles as t on ta.title_id=t.title_id

 --7) print the author name, title name and the publisher name
select a.au_fname as "Name" , t.title,p.pub_name 
 from authors as a join titleauthor as ta on a.au_id=ta.au_id 
 join titles as t on ta.title_id=t.title_id 
 join publishers as p on t.pub_id=p.pub_id

 --8) Print the average price of books pulished by every publisher
 select p.pub_name, AVG(t.price) as "Average Price" 
 from titles as t join publishers as p on t.pub_id=p.pub_id 
 group by p.pub_name

 --9) print the books published by 'Marjorie'
 select title from titles where pub_id in (select pub_id from publishers where pub_name='Marjorie')

 --10) Print the order numbers of books published by 'New Moon Books'
 select distinct s.ord_num from sales s join stores st on s.stor_id=st.stor_id
 join titles t on s.title_id=t.title_id 
 join publishers p on t.pub_id = p.pub_id
 where p.pub_name='New Moon Books';

 --11) Print the number of orders for every publisher
 select p.pub_name, count(distinct s.title_id) as num 
 from publishers p join titles t on p.pub_id=t.pub_id
 join titleauthor ta on t.title_id=ta.title_id
 join sales s on s.title_id=t.title_id
 group by p.pub_name;

 --12) print the order number , book name, quantity, price and the total price for all orders
 select s.ord_num,t.title,s.qty,t.price,s.qty*t.price as "total price"
 from sales s join titles t on s.title_id=t.title_id
 join titleauthor ta on t.title_id = ta.title_id

 --13) print the total order quantity for every book
 select t.title,sum(s.qty)
 from sales s join titles t on s.title_id=t.title_id
 group by t.title;

--14) print the total ordervalue for every book
 select t.title,sum(s.qty*t.price) as "total order"
 from sales s join titles t on s.title_id=t.title_id
 group by t.title;

--15) print the orders that are for the books published by the publisher for which 'Paolo' works for
select s.ord_num,t.title
 from sales s join titles t on s.title_id=t.title_id
 join titleauthor ta on t.title_id = ta.title_id
 join employee e on t.pub_id=e.pub_id
 where e.fname='Paolo';