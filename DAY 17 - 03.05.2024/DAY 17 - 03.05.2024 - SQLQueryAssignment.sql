use Pubs

select * from stores

select * from titles

select * from publishers

select * from sales

-- 1) To Print the storeid and number of orders for the store
select stores.stor_id, count(sales.stor_id) as 'Number of Orders' from stores join sales
on stores.stor_id = sales.stor_id
group by stores.stor_id


-- 2) To print the number of orders for every title
select titles.title ,count(sales.title_id) as 'Number of Orders' from sales join titles
on titles.title_id = sales.title_id
group by titles.title


-- 3) To Print the publisher name and book name
select publishers.pub_name, titles.title from titles join publishers
on titles.pub_id = publishers.pub_id
order by 1

-- 4) To Print the author full name for all the authors
select au_id,concat(au_fname,' ',au_lname) as 'Full Name of Author' from authors

-- 5) To Print the price or every book with tax (price+price*12.36/100)
select title,price + (price * 12.36 / 100) as 'Price of every Book' from titles 

-- 6) To Print the author name, title name
select * from titleauthor
select distinct * from authors
select * from titles

select concat(authors.au_fname,' ',authors.au_lname) as 'Author Name',title as 'Title Name' from titles
join titleauthor on titleauthor.title_id = titles.title_id
join authors on titleauthor.au_id = authors.au_id


-- 7) To print the author name, title name and the publisher name
select concat(authors.au_fname,' ',authors.au_lname) as 'Author Name',title as 'Title Name',pub_name as 'Publisher Name' from titles
join titleauthor on titleauthor.title_id = titles.title_id
join authors on titleauthor.au_id = authors.au_id
join publishers on publishers.pub_id = titles.pub_id


-- 8) To Print the average price of books pulished by every publicher
select * from publishers
select * from titles

select pub_id as 'Publisher ID' ,avg(price) 'Average Price'
from titles group by pub_id

 
 -- 9) To Print the books published by 'Marjorie'
 select title as 'Books Published' from titles 
 where titles.pub_id = (select pub_id from publishers where pub_name='Marjorie')


 -- 10) To Print the order numbers of books published by 'New Moon Books'
 select ord_num from sales where title_id in
(select title_id from titles where pub_id= 
(select pub_id from publishers where pub_name='New Moon Books'))

-- 11) To Print the number of orders for every publisher
select * from publishers
select * from sales

select pub_name 'Publisher Name',count(sales.qty)'Number of orders' 
from publishers
join titles on publishers.pub_id = titles.pub_id
join sales on sales.title_id = titles.title_id
group by publishers.pub_name

-- 12) To print the order number , book name, quantity, price and the total price for all orders
select sales.ord_num 'Order Number' ,
titles.title 'Book Name',
sales.qty 'Quantity',
titles.price 'Price',
(titles.price * sales.qty) 'Total Price'
from sales join titles on titles.title_id = sales.title_id

-- 13) To print he total order quantity fro every book
select title as 'Book', sum(sales.qty) 'Total Order Quantity' 
from titles
join sales on sales.title_id = titles.title_id
group by titles.title

-- 14) To print the total ordervalue for every book
select title as 'Book', sum(sales.qty*price) 'Total Order Value' 
from titles
join sales on sales.title_id = titles.title_id
group by titles.title

-- 15) To print the orders that are for the books published by the publisher for which 'Paolo' works for
select title_id 'Title ID', ord_num 'Order Number' from sales where title_id in
(select  title_id from titles where pub_id=
(select pub_id from employee where fname='Paolo'))