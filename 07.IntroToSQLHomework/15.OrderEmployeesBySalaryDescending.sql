use TelerikAcademy;

select FirstName, LastName, Salary from Employees
where Salary > 50000
order by -Salary;