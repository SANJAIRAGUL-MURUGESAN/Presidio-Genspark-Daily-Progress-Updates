--Create a database
create database dbSalesEmployeeTracker

use dbSalesEmployeeTracker

-- Creating ITEM table
CREATE TABLE Item (
    ItemName VARCHAR(100) PRIMARY KEY,
    ItemType VARCHAR(50),
    ItemColor VARCHAR(50)
);

-- Creating DEPARTMENT table
CREATE TABLE Department (
    DepartmentName VARCHAR(20) PRIMARY KEY,
    DepartmentFloor INT,
    DepartmentPhone VARCHAR(20),
);


-- Creating Employee Table
create table Employees
(EmployeeNo int constraint pk_EmployeeNo primary key,
EmpploeeName VARCHAR(100),
EmployeeSalary DECIMAL(10, 2),
DepartmentName VARCHAR(20) constraint fk_Departmentname references Department(DepartmentName),
BossNo int constraint fk_Bossno references Employees(EmployeeNo));


ALTER TABLE Department
ADD DepartmentHeadId INT CONSTRAINT fk_DepartmentHead references Employees(EmployeeNo);

-- Creating SALES table
CREATE TABLE Sales (
    SalesNo INT IDENTITY(101,1) PRIMARY KEY,
    SalesQuantity INT,
    ItemName VARCHAR(100) CONSTRAINT fk_itemname REFERENCES ITEM(itemname),
    Department VARCHAr(20) CONSTRAINT fk_deptname_sales REFERENCES Department(DepartmentName)
);



-- Inserting Values in Employees Table
INSERT INTO Employees (EmployeeNo,EmpploeeName, EmployeeSalary, DepartmentName, BossNo)
VALUES
    (1, 'Alice', 75000, NULL, NULL),
    (2, 'Ned', 45000, NULL, 1),
    (3, 'Andrew', 25000, NULL, 2),
    (4, 'Clare', 22000, NULL, 2),
    (5, 'Todd', 38000, NULL, 1),
    (6, 'Nancy', 22000, NULL, 5),
    (7, 'Brier', 43000, NULL, 1),
    (8, 'Sarah', 56000, NULL, 7),
    (9, 'Sophile', 35000, NULL, 1),
    (10, 'Sanjay', 15000, NULL, 3),
    (11, 'Rita', 15000, NULL, 4),
    (12, 'Gigi', 16000, NULL, 4),
    (13, 'Maggie', 11000, NULL, 4),
    (14, 'Paul', 15000, NULL, 3),
    (15, 'James', 15000, NULL, 3),
    (16, 'Pat', 15000, NULL, 3),
    (17, 'Mark', 15000, NULL, 3);

select * from Employees;

-- Insert Command to add values in Department
INSERT INTO Department (departmentName, DepartmentFloor, DepartmentPhone, DepartmentHeadId)
VALUES
    ('Management', 5, '34', 1),
    ('Books', 1, '81', 4),
    ('Clothes', 2, '24', 4),
    ('Equipment', 3, '57', 3),
    ('Furniture', 4, '14', 3),
    ('Navigation', 1, '41', 3),
    ('Recreation', 2, '29', 4),
    ('Accounting', 5, '35', 5),
    ('Purchasing', 5, '36', 7),
    ('Personnel', 5, '37', 9),
    ('Marketing', 5, '38', 2);

select * from Department;


-- Update query to set DepartmentName in Employee table
UPDATE Employees
SET DepartmentName = 
    CASE EmployeeNo
        WHEN 1 THEN 'Management'
        WHEN 2 THEN 'Marketing'
        WHEN 3 THEN 'Marketing'
        WHEN 4 THEN 'Marketing'
        WHEN 5 THEN 'Accounting'
        WHEN 6 THEN 'Accounting'
        WHEN 7 THEN 'Purchasing'
        WHEN 8 THEN 'Purchasing'
        WHEN 9 THEN 'Personnel'
        WHEN 10 THEN 'Navigation'
        WHEN 11 THEN 'Books'
        WHEN 12 THEN 'Clothes'
        WHEN 13 THEN 'Clothes'
        WHEN 14 THEN 'Equipment'
        WHEN 15 THEN 'Equipment'
        WHEN 16 THEN 'Furniture'
        WHEN 17 THEN 'Recreation'
    END;

select * from Employees;

--Insert command to add values in ItemTable
INSERT INTO Item (ItemName, ItemType, ItemColor)
VALUES
    ('Pocket Knife-Nile', 'E', 'Brown'),
    ('Pocket Knife-Avon', 'E', 'Brown'),
    ('Compass', 'N', NULL),
    ('Geo positioning system', 'N', NULL),
    ('Elephant Polo stick', 'R', 'Bamboo'),
    ('Camel Saddle', 'R', 'Brown'),
    ('Sextant', 'N', NULL),
    ('Map Measure', 'N', NULL),
    ('Boots-snake proof', 'C', 'Green'),
    ('Pith Helmet', 'C', 'Khaki'),
    ('Hat-polar Explorer', 'C', 'White'),
    ('Exploring in 10 Easy Lessons', 'B', NULL),
    ('Hammock', 'F', 'Khaki'),
    ('How to win Foreign Friends', 'B', NULL),
    ('Map case', 'E', 'Brown'),
    ('Safari Chair', 'F', 'Khaki'),
    ('Safari cooking kit', 'F', 'Khaki'),
    ('Stetson', 'C', 'Black'),
    ('Tent - 2 person', 'F', 'Khaki'),
    ('Tent -8 person', 'F', 'Khaki');

select * from Item;

-- Inserting data into SALES table
INSERT INTO Sales (SalesQuantity, ItemName, Department)
VALUES
    (2, 'Boots-snake proof', 'Clothes'),
    (1, 'Pith Helmet', 'Clothes'),
    (1, 'Sextant', 'Navigation'),
    (3, 'Hat-polar Explorer', 'Clothes'),
    (5, 'Pith Helmet', 'Equipment'),
    (2, 'Pocket Knife-Nile', 'Clothes'),
    (3, 'Pocket Knife-Nile', 'Recreation'),
    (1, 'Compass', 'Navigation'),
    (2, 'Geo positioning system', 'Navigation'),
    (5, 'Map Measure', 'Navigation'),

    (1, 'Geo positioning system', 'Books'),
    (1, 'Sextant', 'Books'),
    (3, 'Pocket Knife-Nile', 'Books'),
    (1, 'Pocket Knife-Nile', 'Navigation'),
    (1, 'Pocket Knife-Nile', 'Equipment'),
    (1, 'Sextant', 'Clothes'),
	(1, 'Exploring in 10 easy lessons', 'Books'),
	(1, 'Elephant Polo stick', 'Recreation'),
    (1, 'Camel Saddle', 'Recreation');
 
SELECT * FROM Sales;

