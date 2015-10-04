use TelerikAcademy;

select FirstName + ' ' + LastName as [Full Name], Salary from Employees
where Salary = 25000 or Salary = 14000 or Salary = 12500 or Salary = 23600;