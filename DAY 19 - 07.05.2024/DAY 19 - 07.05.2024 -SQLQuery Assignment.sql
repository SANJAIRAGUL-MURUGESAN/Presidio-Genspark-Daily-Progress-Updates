use Pubs

-- 1) Create a stored procedure that will take the author firstname and print all the books published
--    by him with the publisher's name
select * from publishers
select * from Titles
select * from titleauthor
select * from authors

Create proc proc_GetBooksByAuthorName(@FirstName varchar(25))
		as
		begin
			select t.title as BookTitle, p.pub_name as "Publisher's Name"
			from titles t
			join titleauthor ta on t.title_id = ta.title_id
			join authors a ON ta.au_id = a.au_id
			join publishers p ON p.pub_id = t.pub_id
			where a.au_fname = @FirstName;
		end;

        exec proc_GetBooksByAuthorName Marjorie
		exec proc_GetBooksByAuthorName Dean

-- 2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity
--and the cost.
select * from sales
select * from employee
select * from titles
select * from publishers

Create proc proc_GetBooksByEmployee(@employeename varchar(20))
as
begin
		select title, price, s.qty as 'Quantity', (price * s.qty)as 'Cost' from titles
		join publishers p on p.pub_id = titles.pub_id
		join employee e on e.pub_id = p.pub_id
		join sales s on s.title_id = titles.title_id
		where e.fname = @employeename
end;

       exec proc_GetBooksByEmployee Paolo
	   exec proc_GetBooksByEmployee Victoria

-- 3) Create a query that will print all names from authors and employees

   select au_fname, au_lname from authors
   UNION
   SELECT fname, lname from employee;

-- 4) Create a query that will fetch the data from sales,titles, publisher and authors table to 
--print title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders,
--print first 5 orders after sorting them based on the price of order
select * from sales
select * from employee
select * from titles
select * from publishers

select top 5 title, p.pub_name, concat(au.au_fname,' ',au.au_lname) as 'Author Name', s.qty as 'Quantity', (titles.price*s.qty) as 'TotalPrice' from titles
join publishers p on p.pub_id = titles.pub_id
join titleauthor ta on ta.title_id = titles.title_id
join authors au on au.au_id = ta.au_id
join sales s on s.title_id = titles.title_id
order by titles.price







