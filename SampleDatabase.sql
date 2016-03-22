USE SampleDB; //primero hay que crear la base de datos llamada SampleDB
Create table tblEmployees
(
    Id int primary key identity,
    Name nvarchar(50),
    Gender nvarchar(10),
    Salary int
)
Go

Insert into tblEmployees values ('Ben', 'Male', 55000)
Insert into tblEmployees values ('Sara', 'Female', 68000)
Insert into tblEmployees values ('Mark', 'Male', 57000)
Insert into tblEmployees values ('Pam', 'Female', 53000)
Insert into tblEmployees values ('Todd', 'Male', 60000)
Go