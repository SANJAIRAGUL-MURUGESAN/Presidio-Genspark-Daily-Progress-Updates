create database pbs

use Pubs

select * from titles

select * from publishers

select * from authors

-- 1) To Print all the titles names
select title  as "Title Name" from titles

-- 2) To Print all the titles that have been published by 1389
select * from titles where pub_id = 1389

-- 3) To Print the books that have price in rangeof 10 to 15
select * from titles where price>=10 and price<=15

-- 4) To Print those books that have no price
select * from titles where price IS NULL

-- 5) To Print the book names that strat with 'The'
select * from titles where title LIKE 'The%'

-- 6) To Print the book names that do not have 'v' in their name
select * from titles where title NOT LIKE '%v%'

-- 7) To Print the books sorted by the royalty
select * from titles Order by royalty

-- 8) To print the books sorted by publisher in descending then by types in asending then by price in descending
select * from titles Order by pub_id Desc, type , price Desc

-- 9) To Print the average price of books in every type
select type, avg(price) as'Average Price of Every Books' from titles
group by type

-- 10)  To Print all the types in uniques
select distinct type as 'Title Name' from titles

-- 11) To Print the first 2 costliest books
select TOP 2 * from titles Order by price desc

-- 12) To Print books that are of type business and have price less than 20 which also have advance greater than 7000
select * from titles
where type = 'business' and price < 20 and advance > 7000

-- 13) To Select those publisher id and number of books which have price between 15 to 25 and have 'It' in its name. Print only those which have count greater than 2. 
-- Also sort the result in ascending order of count
select pub_id, Count(*) as 'Number of Books'
from titles
where price between 15 and 25 and title like '%It%'
group by pub_id
having count(*) > 2
order by Count(*) asc;

-- 14) To Print the Authors who are from 'CA'
select * from authors where state = 'CA'

--15) To Print the count of authors from every state
select state,Count(au_id) as 'Count of Authors' from authors
group by state