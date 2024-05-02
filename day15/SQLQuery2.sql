--Create a database
create database dbEmployeeTracker
--select the databse fro query
use dbEmployeeTracker

--delete databse
use master
go
drop database dbEmployeeTracker

--Create table
create Table Areas
(Area varchar(20),
Zipcode char(5))

select * from Areas

--inbuilt stored procedure
sp_help Areas

--Edit the area colum to be teh primary key
alter table Areas
alter column Area varchar(20) not null
alter table Areas
add constraint pk_Area primary key(Area)

--Drop and re create table to add primary key

drop table Areas

create Table Areas
(Area varchar(20) constraint pk_Area primary key,
Zipcode char(5))

--Alter table to add clolumn
Alter table Areas
add AreaDescription varchar(1000)

--Alter table to delete clolumn
alter table Areas
drop column AreaDescription

--Foreign key with identity
create table Skills(
Skill_id int identity(1,1) constraint pk_skill primary key,
Skill varchar(20),
SkillDescription varchar(100))

sp_help Skills

create table Employee
(id int identity(101,1) constraint pk_EmployeeId primary key,
name varchar(100) ,
DateOfBirth datetime constraint chk_DOB Check(DateOfBirth<Getdate()),
EmployeeArea varchar(20) constraint fk_Area references Areas(Area),
Phone varchar(15),
email varchar(100) not null)

sp_help Employee

create table EmployeeSkill
(Employee_id int constraint fk_skill_eid foreign key references Employee(id),
Skill int constraint fk_Skill_EmplSkill foreign key references Skills(skill_id),
skillLevel float constraint chk_skilllevel check(skillLevel>=0),
constraint pk_employee_skill primary key(EMployee_id,Skill))

sp_help EmployeeSkill

--DML--
Insert into Areas(Area,Zipcode) values('DDDD','12345')
Insert into Areas(Zipcode,Area) values('12333','FFFF')
insert into Areas values('HHHH','12222')
insert into Areas values('IIII','12223'),('KKKK','12121')
insert into Areas values('RRRR','13222')
--Insert Failures
Insert into Areas(Area,Zipcode) values('DDDD','12345')--Primary key duplication
Insert into Areas(Area,Zipcode) values('OOOO','12345334')--Size violation
Insert into Areas(Zipcode) values('12345')--Primary key null

select * from Areas

insert into skills(Skill,SkillDescription) values('C','PLT')
insert into skills(Skill,SkillDescription) values('C++','OOPS'),('Java','Web'),('C#','Web'),('SQL','RDBMS')
select * from skills

--Foreign Key insert
insert into Employee(name,DateOfBirth,EmployeeArea,Phone,Email)
Values('Ramu','2000-12-12','DDDD','9876543210','ramu@gmail.com')
insert into Employee(name,DateOfBirth,EmployeeArea,Phone,Email)
Values('Somu','2001-05-01','FFFF','9988776655','somu@gmail.com')
insert into Employee(name,DateOfBirth,EmployeeArea,Phone,Email)
Values('Tomu','2002-05-01','RRRR','9988776655','Tomu@gmail.com')

select * from Employee

--Employee Skill- Composite key

Insert into EmployeeSkill values(101,3,8)



select * from EmployeeSkill

select * from Employee

--Update 
update Employee set phone = '9876543210'
where id = 101
update Employee set phone = '9988776655'
where id = 105


Insert into EmployeeSkill values(105,2,7)
Insert into EmployeeSkill values(105,3,7)

update EmployeeSkill set skillLevel = 8
where skill = 2 and Employee_id = 101

-- Update the skill level to 5 if it is 7 and to 9 if it is 8 otherwise leave it as it is
update EmployeeSkill set skillLevel = case 
				when skillLevel= 7 then 5
				when skillLevel = 8 then 9
				else skillLevel
				end
where Employee_id = 101

Delete from EmployeeSkill --where Employee_id = 105


select * from areas

delete from Areas where area = 'DDDD'