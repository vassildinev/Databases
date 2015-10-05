use TelerikAcademy;

select FirstName, LastName from Employees e
where len(e.LastName) = 5;