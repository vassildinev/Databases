use TelerikAcademy;

select x.FirstName, x.LastName, y.FirstName + ' ' + y.LastName as Manager from Employees x, Employees y
where x.ManagerId = y.EmployeeId;