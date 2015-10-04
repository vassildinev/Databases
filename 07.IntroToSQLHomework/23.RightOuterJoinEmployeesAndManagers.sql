use TelerikAcademy;

select y.FirstName + ' ' + y.LastName as [Employee Name],
	   x.FirstName + ' ' + x.LastName as [Manager Name]
from Employees x
right outer join Employees y
on x.ManagerID = y.EmployeeID;