use TelerikAcademy;

--username is not first letter + lastname 
--because that way exist duplicate usernames 
--which is not allowed

set identity_insert Users on;
insert into Users(UserId, Username, Password, FullName)
select (5 + EmployeeID), lower(FirstName + LastName), '123456', FirstName + ' ' + LastName from Employees
set identity_insert Users off;