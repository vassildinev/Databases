use TelerikAcademy;

select x.FirstName + ' ' + x.LastName as [Employee Name], 
	   y.Name as [DepartmentName],
	   x.HireDate
from Employees x
inner join Departments y
on x.DepartmentID = y.DepartmentID

where (y.Name = 'Sales' or y.Name = 'Finance') and
	  (datediff(YY, x.HireDate, '2005-01-01 00:00:00') > 0 and 
	   datediff(YY, x.HireDate, '1995-01-01 00:00:00') < 0);
