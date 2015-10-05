use TelerikAcademy;

select FirstName + ' ' + LastName as Employee, Salary from Employees
where Salary <= 1.1 * (select MIN(Salary) from Employees)
order by Salary;