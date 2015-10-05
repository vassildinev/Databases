use TelerikAcademy;

select FirstName + ' ' + LastName as Employee, Salary from Employees
where Salary = (select MIN(Salary) from Employees)
order by FirstName;