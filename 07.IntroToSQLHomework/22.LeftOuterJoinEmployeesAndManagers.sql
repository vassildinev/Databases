use TelerikAcademy;

select x.FirstName + ' ' + x.LastName as [Employee Name],
	   y.FirstName + ' ' + y.LastName as [Manager Name]
from Employees x
left outer join Employees y
on x.ManagerID = y.EmployeeID;