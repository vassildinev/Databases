use TelerikAcademy;

select e.FirstName + ' ' + e.LastName as [Employee],
	   coalesce(i.FirstName + ' ' + i.LastName, 'no manager') as [Manager]
from Employees e
left outer join Employees i on e.ManagerID = i.EmployeeID